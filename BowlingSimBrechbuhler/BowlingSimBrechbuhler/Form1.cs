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
            // how many pins the player hit
            int pinsHit = rand.Next(minPinsHit, maxPinsHit+1);

            // calculate score and increment turnPerFrameCounter
            saveScore(pinsHit);
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

            // check gameover condition
            if(frameCounter == maxFrames)
            {
                // set conditions for the gameover event
                this.finalScoreLabel.Text = "Game Over! " + '\n' + "You're final score is: " + totalScore();
                this.playAgainBtn.Visible = true;
                this.bowlBtn.Visible = false;
                this.cheaterBtn.Visible = false;
                this.zeroBtn.Visible = false;
            }

            // update UI Information
            updateInformationNoFrameCounter(pinsHit, turnPerFrameCounter);

            // if 2 balls have been bowled
            if (turnPerFrameCounter == 2)
            {
                frameCounter++;
                turnPerFrameCounter = 0;
                updateInformationFrameCounter(frameCounter);
                this.totalScoreLabel.Text = "Total Score: " + totalScore();
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
                maxFrames = 11;
            }

            // check gameover condition
            if (frameCounter == maxFrames)
            {
                // set conditions for the gameover event
                this.finalScoreLabel.Visible = true;
                this.finalScoreLabel.Text = "Game Over! " + '\n' + "You're final score is: " + totalScore();
                this.playAgainBtn.Visible = true;
                this.bowlBtn.Visible = false;
                this.cheaterBtn.Visible = false;
                this.zeroBtn.Visible = false;
            }

            // update UI information
            updateInformationNoFrameCounter(pinsHit, turnPerFrameCounter);
            updateInformationFrameCounter(frameCounter);
            this.totalScoreLabel.Text = "Total Score: " + totalScore();
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
            if (frameCounter == maxFrames)
            {
                // set conditions for the gameover event
                this.finalScoreLabel.Visible = true;
                this.finalScoreLabel.Text = "Game Over! " + '\n' + "You're final score is: " + totalScore();
                this.playAgainBtn.Visible = true;
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
                this.totalScoreLabel.Text = "Total Score: " + totalScore();
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

            // set the labels back to deafault
            this.frameLabel.Text = "Frames: ";
            this.turnPerFrameLabel.Text = "Ball: ";
            this.scoreLabel.Text = "Pins Hit:";
            this.displayLabel.Text = "";

            // hid button and final score label
            this.finalScoreLabel.Visible = false;
            this.playAgainBtn.Visible = false;

            // make other buttons visible again
            this.bowlBtn.Visible = true;
            this.cheaterBtn.Visible = true;
            this.zeroBtn.Visible = true;
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
            int totalScore = 0;
            foreach(int n in scores)
            {
                totalScore += n;
            }
            return totalScore;
        }

        // update on screen pinsHit label and turnPerFrameLabel
        private void updateInformationNoFrameCounter(
            int pinsHit, int turnPerFrameCounter)
        {
            // set labels accordingly 
            this.displayLabel.Text = "You hit " + pinsHit + " pins!";
            this.turnPerFrameLabel.Text += turnPerFrameCounter + " | ";
        }

        // update frameCount label
        private void updateInformationFrameCounter(int frameCounter)
        {
            // set labels accordingly 
            this.frameLabel.Text += frameCounter + " | ";
        }
    }
}
