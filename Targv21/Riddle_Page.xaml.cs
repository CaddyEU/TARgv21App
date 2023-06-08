using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;
using System.Collections.Generic;

namespace Targv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Riddle_Page : ContentPage
    {
        private int currentRiddleIndex = 0;
        private int score = 0;
        private Timer timer;
        private const int TimePerRiddleInSeconds = 15;
        private bool gameStarted = false;

        private List<Riddle> riddles = new List<Riddle>
        {
            new Riddle("What goes up but never comes back down?", "Age"),
            new Riddle("If you drop a yellow hat in the Red Sea, what does it become?", "Wet"),
            new Riddle("What’s bright orange with green on top and sounds like a parrot?", "Carrot")
        };

        private void InitializeRiddleTimers()
        {
            foreach (var riddle in riddles)
            {
                riddle.StartTime = DateTime.Now;
            }
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            StartButton.IsEnabled = false;
            CheckAnswerButton.IsEnabled = true;
            InitializeRiddleTimers(); // Initialize the start time for each riddle
            StartTimer();
            gameStarted = true; // Set the gameStarted flag to true
        }

        private void NewGameButton_Clicked(object sender, EventArgs e)
        {
            currentRiddleIndex = 0;
            score = 0;
            ShowNextRiddle();
            ScoreLabel.Text = $"Score: {score}";
            StartButton.IsEnabled = true;
            NewGameButton.IsEnabled = false;
        }

        public Riddle_Page()
        {
            InitializeComponent();
            ShowNextRiddle();
            CheckAnswerButton.Clicked += CheckAnswerButton_Clicked; // Move this line before disabling the button
            CheckAnswerButton.IsEnabled = false; // Disable the Check Answer button initially
            StartButton.IsEnabled = true; // Enable the Start button initially
            NewGameButton.IsEnabled = false; // Disable the New Game button initially
            gameStarted = false;
        }

        private void ShowNextRiddle()
        {
            ResetTimer(); // Reset the timer before showing the next riddle

            if (currentRiddleIndex < riddles.Count)
            {
                RiddleLabel.Text = riddles[currentRiddleIndex].Question;
                currentRiddleIndex++; // Move the currentRiddleIndex increment here
            }
            else
            {
                timer.Stop();
                DisplayAlert("Congratulations!", $"You solved all the riddles!\nFinal score: {score}", "OK");
                NewGameButton.IsEnabled = true; // Enable the New Game button after completing all riddles
            }
        }


        private void CheckAnswerButton_Clicked(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                DisplayAlert("Game Not Started", "Please press 'Start' to begin the game.", "OK");
                return;
            }

            string userAnswer = AnswerEntry.Text.Trim();

            if (currentRiddleIndex > 0 && currentRiddleIndex <= riddles.Count)
            {
                // Compare the answers with case-insensitivity
                if (string.Equals(userAnswer, riddles[currentRiddleIndex - 1].Answer.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    score++;
                    AnswerEntry.Text = string.Empty;
                    ScoreLabel.Text = $"Score: {score}";
                    ShowNextRiddle(); // Move ShowNextRiddle() before displaying the "Correct" message
                    DisplayAlert("Correct!", "You solved the riddle!", "OK");
                }
                else if (!string.IsNullOrEmpty(userAnswer)) // Check if the user has attempted to solve the riddle
                {
                    DisplayAlert("Incorrect", "Try again!", "OK");
                }

                ResetTimer();
            }
        }


        private void StartTimer()
        {
            if (timer == null)
            {
                timer = new Timer();
                timer.Interval = 1000; // 1 second
                timer.Elapsed += TimerElapsed;
                timer.Start(); // Start the timer
            }
            else
            {
                timer.Stop();
                timer.Start(); // Restart the timer
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (currentRiddleIndex > 0 && currentRiddleIndex <= riddles.Count)
                {
                    var remainingSeconds = TimePerRiddleInSeconds - (int)e.SignalTime.Subtract(riddles[currentRiddleIndex - 1].StartTime).TotalSeconds;
                    TimeLabel.Text = $"Time left: {remainingSeconds} seconds";

                    if (remainingSeconds <= 0)
                    {
                        DisplayAlert("Time's up!", "You ran out of time!", "OK");
                        ResetTimer();
                        ShowNextRiddle();
                    }
                }
            });
        }


        private void ResetTimer()
        {
            if (currentRiddleIndex > 0 && currentRiddleIndex <= riddles.Count)
            {
                riddles[currentRiddleIndex - 1].StartTime = DateTime.Now;
            }
        }
    }

    public class Riddle
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime StartTime { get; set; }

        public Riddle(string question, string answer)
        {
            Question = question;
            Answer = answer;
            StartTime = DateTime.Now;
        }
    }
}