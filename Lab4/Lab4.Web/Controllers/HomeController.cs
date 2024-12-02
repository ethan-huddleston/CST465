using Lab3.Objects;
using MyExtensions;
public class HomeController : Controller

{

    public IActionResult Index() 

    {

         return View(); 

    }

    public IActionResult Laborers()
    {
        ChoreWorkforce workforce = new ChoreWorkforce();
        ChoreWorkforce temp = new ChoreWorkforce();
        workforce.Laborers.Add(new ChoreLaborer(){ Name = "Bob", Age = 7, Difficulty = 5 });
        workforce.Laborers.Add(new ChoreLaborer(){ Name = "Billy", Age = 13, Difficulty = 9 });
        workforce.Laborers.Add(new ChoreLaborer(){ Name = "Brody", Age = 23, Difficulty = 10 });
        workforce.Laborers.Add(new ChoreLaborer(){ Name = "Benji", Age = 17, Difficulty = 3 });
        for(int i = 0; i < 30; i++)
        {
            workforce.AddRandomLaborer();
        }
        IEnumerable<ChoreLaborer> query = workforce.Laborers.Where(Laborer => (Laborer?.Age?? -1 ) > 2 && (Laborer?.Age?? -1) < 11 );
        query = query.Where(Laborer => (Laborer?.Difficulty?? 11) < 8 );
        query.OrderBy(laborer => laborer.Name);

        foreach(var laborer in query)
        {
            temp.Laborers.Add(laborer);
        }


        return View(temp);
    }

}