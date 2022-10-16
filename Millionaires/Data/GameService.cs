namespace Millionaires.Data
{
    
    public class GameService
    {  
        private bool isFiftyFiftyAvaible = true;
        private bool isAudienceVoteAvaible = true;
        private bool isCallToFrientAvaible = true;
        private bool isMainRewardWon = false;
        private bool gameOver;
        public int[] rewardValueByLevel = {100,500,2000,6000,12000,320000,100000,2500000,500000,10000000 };
        private int currentLevel;
        private List<Question> questions;
        private Question currentQuestion;

        public void SetupGame(List<Question> questions)
        {
        isFiftyFiftyAvaible = true;
        isAudienceVoteAvaible = true;
        isCallToFrientAvaible = true;
        gameOver = false;
            isMainRewardWon = false;
            currentLevel = 0;
            this.questions = questions;
            currentQuestion = questions.ElementAt(currentLevel);
        }
        public bool getIsFiftyFiftyAvaible()
        {
            return isFiftyFiftyAvaible;
        }
        public bool getIsCallToFrientAvaible()
        {
            return isCallToFrientAvaible;
        }
        public bool getIsAudienceVoteAvaible()
        {
            return isAudienceVoteAvaible;
        }
        public void setIsFiftyFiftyAvaibleFalse()
        {
            isFiftyFiftyAvaible = false;
        }
        public void setIsCallToFrientAvaibleFalse()
        {
            isCallToFrientAvaible = false;
        }
        public void setIsAudienceVoteAvaibleFalse()
        {
            isAudienceVoteAvaible = false;
        }
        public bool getIsGameWon()
        {
            return isMainRewardWon;
        }
        public bool getGameStatus()
        {
            return gameOver;
        }
        public Task<Question> GetQuestion()
        {
            return Task.FromResult(currentQuestion);
        }
        public Task<int> GetCurrentLevel()
        {
            return Task.FromResult(currentLevel);
        }
        public void SubmitQuestion(string answereValue)
        {
            if(currentQuestion.CorrectAnswere == answereValue)
            {
                if(currentLevel>=9)
                {
                    //main prize won
                    isMainRewardWon = true;
                }
                else
                {
                currentLevel++;
                currentQuestion = questions.ElementAt(currentLevel);
                }

            }
            else
            {
                gameOver = true;
            }
        }


    }
}
