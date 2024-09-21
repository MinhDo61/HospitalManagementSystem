using System;
using System.Collections.Generic;
using System.IO;

namespace HospitalManagementSystem
{
    public class PatientMenu
    {
        private string patientId;

        public PatientMenu(string patientId)
        {
            this.patientId = patientId;
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Patient Menu");
                Console.WriteLine("1. List Patient Details");
                Console.WriteLine("2. List My Doctor Details");
                Console.WriteLine("3. List All Appointments");
                Console.WriteLine("4. Book Appointment");
                Console.WriteLine("5. Logout");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ListPatientDetails();
                        break;
                    case "2":
                        ListMyDoctorDetails();
                        break;
                    case "3":
                        ListAllAppointments();
                        break;
                    case "4":
                        BookAppointment();
                        break;
                    case "5":
                        // Return to Login Menu
                        return;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private void ListPatientDetails()
        {
            Console.Clear();
            Console.WriteLine("Patient Details");
            // Implementation to list patient details
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        private void ListMyDoctorDetails()
        {
            Console.Clear();
            Console.WriteLine("Doctor Details");
            // Implementation to list doctor's details
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        private void ListAllAppointments()
        {
            Console.Clear();
            Console.WriteLine("All Appointments");
            // Implementation to list all appointments
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        private void BookAppointment()
        {
            Console.Clear();
            Console.WriteLine("Book Appointment");
            // Implementation to book an appointment
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}
