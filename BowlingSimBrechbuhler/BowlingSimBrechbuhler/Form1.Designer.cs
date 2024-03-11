using System.Transactions;

namespace BowlingSimBrechbuhler
{
    partial class bowlingSimulatorForm
    {
        private System.ComponentModel.IContainer components = null;

        private Button bowlBtn;
        private Button cheaterBtn;
        private Button zeroBtn;
        private Label frameLabel;
        private Label turnPerFrameLabel;
        private Button quitBtn;

        private int frameCounter = 0;
        private int turnPerFrameCounter = 0;
        private int maxPinsHit = 10;
        private int minPinsHit = 0;
        private int maxFrames = 10;
        private int finalScore = 0; 
        private int previousPinsHit = 0;
        Random rand = new Random();
        private List<int> scores = new List<int>();

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            bowlBtn = new Button();
            cheaterBtn = new Button();
            zeroBtn = new Button();
            frameLabel = new Label();
            turnPerFrameLabel = new Label();
            quitBtn = new Button();
            scoreLabel = new Label();
            displayLabel = new Label();
            totalScoreLabel = new Label();
            endOfFrameLabel = new Label();
            finalScoreLabel = new Label();
            playAgainBtn = new Button();
            saveScoreBtn = new Button();
            SuspendLayout();
            // 
            // bowlBtn
            // 
            bowlBtn.Location = new Point(350, 415);
            bowlBtn.Name = "bowlBtn";
            bowlBtn.Size = new Size(75, 50);
            bowlBtn.TabIndex = 0;
            bowlBtn.Text = "Bowl!";
            bowlBtn.UseMnemonic = false;
            bowlBtn.UseVisualStyleBackColor = true;
            bowlBtn.Click += bowlButton;
            // 
            // cheaterBtn
            // 
            cheaterBtn.Location = new Point(589, 415);
            cheaterBtn.Name = "cheaterBtn";
            cheaterBtn.Size = new Size(75, 50);
            cheaterBtn.TabIndex = 1;
            cheaterBtn.Text = "Cheater";
            cheaterBtn.UseMnemonic = false;
            cheaterBtn.UseVisualStyleBackColor = true;
            cheaterBtn.Click += cheaterButton;
            // 
            // zeroBtn
            // 
            zeroBtn.Location = new Point(681, 415);
            zeroBtn.Name = "zeroBtn";
            zeroBtn.Size = new Size(75, 50);
            zeroBtn.TabIndex = 2;
            zeroBtn.Text = "0";
            zeroBtn.UseMnemonic = false;
            zeroBtn.UseVisualStyleBackColor = true;
            zeroBtn.Click += zeroButton;
            // 
            // frameLabel
            // 
            frameLabel.AutoSize = true;
            frameLabel.Location = new Point(25, 50);
            frameLabel.Name = "frameLabel";
            frameLabel.Size = new Size(46, 15);
            frameLabel.TabIndex = 3;
            frameLabel.Text = "Frame: ";
            // 
            // turnPerFrameLabel
            // 
            turnPerFrameLabel.AutoSize = true;
            turnPerFrameLabel.Location = new Point(25, 80);
            turnPerFrameLabel.Name = "turnPerFrameLabel";
            turnPerFrameLabel.Size = new Size(32, 15);
            turnPerFrameLabel.TabIndex = 4;
            turnPerFrameLabel.Text = "Ball: ";
            // 
            // quitBtn
            // 
            quitBtn.Location = new Point(25, 415);
            quitBtn.Name = "quitBtn";
            quitBtn.Size = new Size(75, 50);
            quitBtn.TabIndex = 5;
            quitBtn.Text = "Quit";
            quitBtn.UseMnemonic = false;
            quitBtn.UseVisualStyleBackColor = true;
            quitBtn.Click += quitButton;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new Point(25, 113);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(54, 15);
            scoreLabel.TabIndex = 7;
            scoreLabel.Text = "Pins Hit: ";
            // 
            // displayLabel
            // 
            displayLabel.AutoSize = true;
            displayLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            displayLabel.Location = new Point(297, 223);
            displayLabel.Name = "displayLabel";
            displayLabel.Size = new Size(0, 37);
            displayLabel.TabIndex = 9;
            // 
            // totalScoreLabel
            // 
            totalScoreLabel.AutoSize = true;
            totalScoreLabel.Location = new Point(25, 138);
            totalScoreLabel.Name = "totalScoreLabel";
            totalScoreLabel.Size = new Size(0, 18);
            totalScoreLabel.TabIndex = 10;
            totalScoreLabel.UseCompatibleTextRendering = true;
            // 
            // endOfFrameLabel
            // 
            endOfFrameLabel.AutoSize = true;
            endOfFrameLabel.Location = new Point(25, 164);
            endOfFrameLabel.Name = "endOfFrameLabel";
            endOfFrameLabel.Size = new Size(0, 15);
            endOfFrameLabel.TabIndex = 11;
            // 
            // finalScoreLabel
            // 
            finalScoreLabel.AutoSize = true;
            finalScoreLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            finalScoreLabel.Location = new Point(128, 358);
            finalScoreLabel.Name = "finalScoreLabel";
            finalScoreLabel.Size = new Size(0, 25);
            finalScoreLabel.TabIndex = 12;
            // 
            // playAgainBtn
            // 
            playAgainBtn.Location = new Point(128, 415);
            playAgainBtn.Name = "playAgainBtn";
            playAgainBtn.Size = new Size(75, 50);
            playAgainBtn.TabIndex = 13;
            playAgainBtn.Text = "Play Again!";
            playAgainBtn.UseMnemonic = false;
            playAgainBtn.UseVisualStyleBackColor = true;
            playAgainBtn.Visible = false;
            playAgainBtn.Click += this.playAgainButton;
            // 
            // saveScoreBtn
            // 
            saveScoreBtn.Location = new Point(209, 415);
            saveScoreBtn.Name = "saveScoreBtn";
            saveScoreBtn.Size = new Size(75, 50);
            saveScoreBtn.TabIndex = 14;
            saveScoreBtn.Text = "Save Score!";
            saveScoreBtn.UseMnemonic = false;
            saveScoreBtn.UseVisualStyleBackColor = true;
            saveScoreBtn.Visible = false;
            saveScoreBtn.Visible = false;
            saveScoreBtn.Click += this.saveScoreButton;
            // 
            // bowlingSimulatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(784, 561);
            Controls.Add(saveScoreBtn);
            Controls.Add(playAgainBtn);
            Controls.Add(finalScoreLabel);
            Controls.Add(endOfFrameLabel);
            Controls.Add(totalScoreLabel);
            Controls.Add(displayLabel);
            Controls.Add(scoreLabel);
            Controls.Add(quitBtn);
            Controls.Add(turnPerFrameLabel);
            Controls.Add(frameLabel);
            Controls.Add(zeroBtn);
            Controls.Add(cheaterBtn);
            Controls.Add(bowlBtn);
            Name = "bowlingSimulatorForm";
            Text = "Bowling Simulator";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label scoreLabel;
        private Label displayLabel;
        private Label totalScoreLabel;
        private Label endOfFrameLabel;
        private Label finalScoreLabel;
        private Button playAgainBtn;
        private Button saveScoreBtn;
    }
}
