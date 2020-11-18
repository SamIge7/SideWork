﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{

    class Program
    {
        static void Main(string[] args)
        {
            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            //WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            //del1 += del2 + del3;

            //int finalHours = del1(10, WorkType.GenerateReports);
            //Console.WriteLine(finalHours);

            var worker = new Worker();

            worker.WorkPerformed += worker_WorkPerformed;
            worker.WorkCompleted += worker_WorkCompleted;

            worker.DoWork(8, WorkType.GenerateReports);
            Console.Read();
        }

        private static void worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Worker is done");
        }

        private static void worker_WorkPerformed(object sender, WorkerPerformedEventArgs e)
        {
            Console.WriteLine("Hours worked: " + e.Hours + ", Work: " + e.WorkType);
        }

        //static void DoWork(WorkPerformedHandler del)
        //{
        //    del(5, WorkType.GoToMeetings);
        //}

        static int WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed1 executed " + hours.ToString());
            return hours + 1;
        }

        static int WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed2 executed " + hours.ToString());
            return hours + 2;
        }

        static int WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed3 executed " + hours.ToString());
            return hours + 3;
        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
