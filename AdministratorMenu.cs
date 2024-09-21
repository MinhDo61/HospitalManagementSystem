using System;
using System.Collections.Generic;
using System.IO;

namespace HospitalManagementSystem
{
    public class AdministratorMenu
    {
        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Administrator Menu");
                Console.WriteLine("1. List All Doctors");
                Console.WriteLine("2. Check Doctor Details");
                Console.WriteLine("3. List All Patients");
                Console.WriteLine("4. Check Patient Details");
                Console.WriteLine("5. Add Patient");
                Console.WriteLine("6. Logout");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ListAllDoctors();
                        break;
                    case "2":
                        CheckDoctorDetails();
                        break;
                    case "3":
                        ListAllPatients();
                        break;
                    case "4":
                        CheckPatientDetails();
                        break;
                    case "5":
                        AddPatient();
                        break;
                    case "6":
                        // Return to Login Menu
                        return;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private void ListAllDoctors()
        {
            Console.Clear();
            Console.WriteLine("All Doctors");
            // Implementation to list all doctors
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        private void CheckDoctorDetails()
        {
            Console.Clear();
            Console.WriteLine("Check Doctor Details");
            // Implementation to check doctor details
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        private void ListAllPatients()
        {
            Console.Clear();
            Console.WriteLine("All Patients");
            // Implementation to list all patients
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        private void CheckPatientDetails()
        {
            Console.Clear();
            Console.WriteLine("Check Patient Details");
            // Implementation to check patient details
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        private void AddPatient()
        {
            Console.Clear();
            Console.WriteLine("Add Patient");
            // Implementation to add a new patient
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}
