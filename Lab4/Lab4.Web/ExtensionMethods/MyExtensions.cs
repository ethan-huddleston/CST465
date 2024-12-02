using Lab3.Objects;

namespace MyExtensions
{
   
    public static class MyExtensions
    {
        public static void AddLaborer(this ChoreWorkforce workforce,string name, int age, int difficulty)
        {
            workforce.Laborers.Add(new ChoreLaborer(){ Name = name , Age = age, Difficulty = difficulty });            
        }
        public static void AddRandomLaborer(this ChoreWorkforce workforce)
        {
            Random rnd = new();
            var rand = new Random();
           
            string[] names = {"Benjamin","Beckett","Blake","Briar","Billie","Bridget","Bruno","Barrett","Bella","Brody","Bellamy"};
            int Index = rnd.Next(names.Length);
             ChoreLaborer temp = new ChoreLaborer(){Name = names[Index] , Age = rand.Next(1,19), Difficulty = rand.Next(1,11)};
            if(temp.Difficulty == 10)
            {
                 workforce.Laborers.Add(null);
            }
            else
            {
                workforce.Laborers.Add(temp); 
            }
            

        }
    }
}