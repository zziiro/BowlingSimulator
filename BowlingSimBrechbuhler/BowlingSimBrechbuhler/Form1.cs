using System.Net.Sockets;
using System.Security.AccessControl;

namespace BowlingSimBrechbuhler
{
    public partial class bowlingSimulatorForm : Form
    {
        public bowlingSimulatorForm()
        {
            InitializeComponent();
        }

        private void bowlButton(object sender, EventArgs e)
        {

            // check gameover condition
            if (frameCounter > maxFrames || frameCounter == maxFrames)
            {
                // set conditions for the gameover event
                this.finalScoreLabel.Visible = true;
                this.finalScoreLabel.Text = "Game Over! " + '\n' + "You're final score is: " + (totalScore() - scores[scores.Count - 1]);
                this.playAgainBtn.Visible = true;
                this.saveScoreBtn.Visible = true;
                this.bowlBtn.Visible = false;
                this.cheaterBtn.Visible = false;
                this.zeroBtn.Visible = false;
            }

            // bowl 
            int pinsHit = rand.Next(minPinsHit, maxPinsHit + 1);

            // change amount of pins available to hit if the the first ball has been thrown
            if (turnPerFrameCounter == 1)
            {
                int pinsLeft = maxPinsHit - (scores[scores.Count - 1]);
                pinsHit = rand.Next(minPinsHit, pinsLeft);
            }

            // calculate score and increment turnPerFrameCounter and add score to scores List
            saveScore(pinsHit);
            finalScore +=scores[scores.Count-1];
            turnPerFrameCounter++;

            // check if the first bowl thrown was a strike
            if(turnPerFrameCounter == 1 && pinsHit == maxPinsHit)
            {
                // set turn PerframeCount to 2;
                turnPerFrameCounter = 2;
            }

            // check if 10th frame strike
            if(frameCounter == maxFrames && pinsHit == maxPinsHit)
            {
                maxFrames=11;
            }

            // update UI Information
            updateInformationNoFrameCounter(pinsHit, turnPerFrameCounter);

            // if 2 balls have been bowled
            if (turnPerFrameCounter == 2)
            {
                // update and reset variables back to 0
                frameCounter++;
                turnPerFrameCounter = 0;
                maxPinsHit = 10;
                updateInformationFrameCounter(frameCounter);
                this.totalScoreLabel.Text = "Current Score: " + finalScore;
                this.endOfFrameLabel.Text = "End of Frame: " + frameCounter.ToString();
            }
        }

        private void cheaterButton(object sender, EventArgs e)
        {
            // initialize pins hit to 10;
            int pinsHit = 10;
            saveScore(pinsHit);

            // increment frameCounter and turnPerFrameCounter;
            frameCounter++;
            

            // check if 10th frame strike
            if (frameCounter == maxFrames && pinsHit == maxPinsHit)
            {
                maxFrames=11;
            }

            // check gameover condition
            if (frameCounter > maxFrames || frameCounter == maxFrames)
            {
                // set conditions for the gameover event
                this.finalScoreLabel.Visible = true;
                this.finalScoreLabel.Text = "Game Over! " + '\n' + "You're final score is: " + totalScore();
                this.playAgainBtn.Visible = true;
                this.saveScoreBtn.Visible = true;
                this.bowlBtn.Visible = false;
                this.cheaterBtn.Visible = false;
                this.zeroBtn.Visible = false;
            }

            // update UI information
            updateInformationNoFrameCounter(pinsHit, turnPerFrameCounter);
            updateInformationFrameCounter(frameCounter);
            this.totalScoreLabel.Text = "Current Score: " + (totalScore() - scores[scores.Count - 1]);
            this.scoreLabel.Text += " - ";
            this.endOfFrameLabel.Text = "End of Frame: " + frameCounter.ToString();
        }

        // zero button
        private void zeroButton(object sender, EventArgs e)
        {
            // how many pins the player hit
            int pinsHit = 0;

            // calculate score and increment turnPerFrameCounter
            saveScore(pinsHit);
            turnPerFrameCounter++;

            // check gameover condition
            if (frameCounter > maxFrames || frameCounter == maxFrames)
            {
                // set conditions for the gameover event
                this.finalScoreLabel.Visible = true;
                this.finalScoreLabel.Text = "Game Over! " + '\n' + "You're final score is: " + (totalScore());
                this.playAgainBtn.Visible = true;
                this.saveScoreBtn.Visible = true;
                this.bowlBtn.Visible = false;
                this.cheaterBtn.Visible = false;
                this.zeroBtn.Visible = false;
            }

            // update UI information
            updateInformationNoFrameCounter(pinsHit, turnPerFrameCounter);

            // if 2 balls have been bowled
            if (turnPerFrameCounter == 2)
            {
                frameCounter++;
                turnPerFrameCounter = 0;
                updateInformationFrameCounter(frameCounter);
                this.totalScoreLabel.Text = "Current Score: " + (totalScore());
            }
        }

        public void quitButton(object sender, EventArgs e)
        {
            this.Close();
        }

        public void playAgainButton(object sender, EventArgs e)
        {
            // set all variables back to zero
            scores.Clear();
            turnPerFrameCounter = 0;
            frameCounter = 0;
            maxFrames = 10;
            finalScore= 0;

            // clear heap for stack overflow errors 
            /* not sure if this is going to causes overflow errors if someone 
             * plays to much because Lists are allocated on the heap */
            GC.Collect();

            // set the labels back to deafault
            this.frameLabel.Text = "Frames: ";
            this.turnPerFrameLabel.Text = "Ball: ";
            this.scoreLabel.Text = "Pins Hit:";
            this.displayLabel.Text = "";
            this.endOfFrameLabel.Text = "End of Frame: ";

            // hide button and final score label
            this.finalScoreLabel.Visible = false;
            this.playAgainBtn.Visible = false;
            this.saveScoreBtn.Visible = false;

            // make other buttons visible again
            this.bowlBtn.Visible = true;
            this.cheaterBtn.Visible = true;
            this.zeroBtn.Visible = true;
        }

        // save score button
        public void saveScoreButton(object sender, EventArgs e)
        {
            try
            {
                // cwd
                string filename = "scores.txt";
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), filename);

                // check if file already exists
                if (!File.Exists(filePath))
                {
                    using(FileStream fs = File.Create(filePath))
                    {
                        using(StreamWriter writer = new StreamWriter(filename))
                        {
                            // write to newly created file
                            int correctedScore = finalScore - (scores[scores.Count-1]);
                            writer.WriteLine(correctedScore.ToString());
                        }
                    }
                }

                // if file exists
                using(StreamWriter writer = new StreamWriter("scores.txt"))
                {
                    // write score to file
                    int correctedScore = finalScore - (scores[scores.Count - 1]);
                    writer.WriteLine(correctedScore.ToString());
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Error attempting to save file..");
                Console.WriteLine("[ERROR] - " + ex.ToString());
            }

            this.saveScoreBtn.Visible = false;
        }

        // calculate scores
        private void saveScore(int pinsHit)
        {
            // send score to array
            scores.Add(pinsHit);

            this.scoreLabel.Text += "[" + pinsHit.ToString() + "]";
        }

        // calculate total score
        private int totalScore()
        {
            int scoresSize = scores.Count-1;
            
            finalScore+=scores[scoresSize];
            
            return finalScore;
        }

        // update on screen pinsHit label and turnPerFrameLabel
        private void updateInformationNoFrameCounter(
            int pinsHit, int turnPerFrameCounter)
        {
            // set labels accordingly 
            this.displayLabel.Text = "You hit " + pinsHit + " pins!";
            this.turnPerFrameLabel.Text += turnPerFrameCounter + " | ";
            if(turnPerFrameCounter == 2)
            {
                this.scoreLabel.Text += " - ";
            }
        }

        // update frameCount label
        private void updateInformationFrameCounter(int frameCounter)
        {
            // set labels accordingly 
            this.frameLabel.Text += frameCounter + " | ";
        }
    }
}
