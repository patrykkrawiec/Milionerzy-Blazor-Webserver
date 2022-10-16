namespace Millionaires.Data
{
    public class QuestionsService
    {
        private List<Question> questions;

        public QuestionsService()
        {
            questions = new List<Question>();  
        }
       
        public int AddQuestion(string questionText,string answereA, string answereB, string answereC, string answereD, string correctAnswere)
        {
            try
            {
                questions.Add(new Question {QuestionId = questions.Count,
                QuestionText=questionText,AnswereA=answereA,AnswereB=answereB,
                AnswereC=answereC,AnswereD=answereD,CorrectAnswere=correctAnswere});
            }
            catch(Exception ex)
            {
                return 1;
            }
            return 0;
        }
        public Task<List<Question>> GetQuestions()
        {
            List<Question> questionsSelected = new List<Question>();
            Random random = new Random();
            while(questionsSelected.Count<10)
            {
                int randomIndex = random.Next(0, questions.Count - 1);
                if(!questionsSelected.Contains(questions.ElementAt(randomIndex)))
                {
                    questionsSelected.Add(questions.ElementAt(randomIndex));
                }
            }
            
            return Task.FromResult(questionsSelected);
        }
        public Task<List<Question>> GetAllQuestions()
        {
            return Task.FromResult(questions);
        }
        public bool isQuestionsReady()
        {
            if(questions.Count>=10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
