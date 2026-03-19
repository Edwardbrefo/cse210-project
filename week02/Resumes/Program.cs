using System;

class Program
{
    static void Main(string[] args)
    {
          Job job1 = new Job();
          job1._jobTitle = "Software Engineer";
          job1._Company = "Microsoft";
            job1._startYear = 2020;
            job1._endYear = 2023;

        Resume myResume = new Resume();
        myResume._name ="Edward Brefo";
        myResume._jobs = new List<Job>();

        myResume._jobs.Add(job1);
       

        myResume.Display();  
    }
}
