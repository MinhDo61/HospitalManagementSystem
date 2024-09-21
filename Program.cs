using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string patientsLoginFile = "patientslogin.txt";
        string doctorsLoginFile = "doctorslogin.txt";
        string adminsFile = "admins.txt";
        string patientsDetailFile = "patientsdetail.txt";
        string doctorsDetailFile = "doctorsdetail.txt";
        string appointmentsFile = "appointments.txt";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Hospital Management System");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Clear();
                Console.Write("Enter ID: ");
                string id = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = ReadPassword();

                bool valid = ValidateLogin(id, password, patientsLoginFile) ||
                             ValidateLogin(id, password, doctorsLoginFile) ||
                             ValidateLogin(id, password, adminsFile);

                if (valid)
                {
                    Console.WriteLine("Login successful!");
                    ShowMenu(id, patientsLoginFile, doctorsLoginFile, adminsFile, patientsDetailFile, doctorsDetailFile, appointmentsFile);
                }
                else
                {
                    Console.WriteLine("Invalid ID or password.");
                    Console.WriteLine("Press any key to return to the main menu.");
                    Console.ReadKey();
                }
            }
            else if (choice == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Press any key to try again.");
                Console.ReadKey();
            }
        }
    }

    static bool ValidateLogin(string id, string password, string fileName)
    {
        try
        {
            foreach (var line in File.ReadLines(fileName))
            {
                var parts = line.Split(',');
                if (parts.Length == 2 && parts[0] == id && parts[1] == password)
                {
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file {fileName}: {ex.Message}");
        }
        return false;
    }

    static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
        }
        while (key.Key != ConsoleKey.Enter);
        Console.WriteLine();
        return password;
    }

    static void ShowMenu(string id, string patientsLoginFile, string doctorsLoginFile, string adminsFile, 
                         string patientsDetailFile, string doctorsDetailFile, string appointmentsFile)
    {
        string role = GetRole(id, patientsLoginFile, doctorsLoginFile, adminsFile);
        while (true)
        {
            Console.Clear();
            switch (role)
            {
                case "patient":
                    ShowPatientMenu(id, patientsDetailFile, doctorsDetailFile, appointmentsFile);
                    break;
                case "doctor":
                    ShowDoctorMenu(id, patientsDetailFile, doctorsDetailFile, appointmentsFile);
                    break;
                case "admin":
                    ShowAdminMenu(id, patientsDetailFile, doctorsDetailFile, appointmentsFile);
                    break;
                default:
                    Console.WriteLine("Invalid role. Logging out...");
                    return;
            }
        }
    }

    static string GetRole(string id, string patientsLoginFile, string doctorsLoginFile, string adminsFile)
    {
        if (IsInFile(id, patientsLoginFile))
            return "patient";
        if (IsInFile(id, doctorsLoginFile))
            return "doctor";
        if (IsInFile(id, adminsFile))
            return "admin";
        return "unknown";
    }

    static bool IsInFile(string id, string fileName)
    {
        foreach (var line in File.ReadLines(fileName))
        {
            var parts = line.Split(',');
            if (parts.Length > 0 && parts[0] == id)
            {
                return true;
            }
        }
        return false;
    }

    static void ShowPatientMenu(string id, string patientsDetailFile, string doctorsDetailFile, string appointmentsFile)
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
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListPatientDetails(id, patientsDetailFile);
                    break;
                case "2":
                    ListMyDoctorDetails(id, patientsDetailFile, doctorsDetailFile);
                    break;
                case "3":
                    ListAppointments(appointmentsFile);
                    break;
                case "4":
                    BookAppointment(id, patientsDetailFile, doctorsDetailFile, appointmentsFile);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ShowDoctorMenu(string id, string patientsDetailFile, string doctorsDetailFile, string appointmentsFile)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Doctor Menu");
            Console.WriteLine("1. List Doctor Details");
            Console.WriteLine("2. List Patients");
            Console.WriteLine("3. List Appointments");
            Console.WriteLine("4. Check Particular Patient");
            Console.WriteLine("5. List Appointments With Patient");
            Console.WriteLine("6. Logout");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListDoctorDetails(id, doctorsDetailFile);
                    break;
                case "2":
                    ListPatients(patientsDetailFile, doctorsDetailFile);
                    break;
                case "3":
                    ListAppointments(appointmentsFile);
                    break;
                case "4":
                    CheckParticularPatient(patientsDetailFile);
                    break;
                case "5":
                    ListAppointmentsWithPatient(id, appointmentsFile);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ShowAdminMenu(string id, string patientsDetailFile, string doctorsDetailFile, string appointmentsFile)
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
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListAllDoctors(doctorsDetailFile);
                    break;
                case "2":
                    CheckDoctorDetails(doctorsDetailFile);
                    break;
                case "3":
                    ListAllPatients(patientsDetailFile);
                    break;
                case "4":
                    CheckPatientDetails(patientsDetailFile);
                    break;
                case "5":
                    AddPatient(patientsDetailFile);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ListPatientDetails(string id, string patientsDetailFile)
    {
        foreach (var line in File.ReadLines(patientsDetailFile))
        {
            var parts = line.Split(',');
            if (parts.Length > 2 && parts[0] == id)
            {
                Console.WriteLine($"ID: {parts[0]}");
                Console.WriteLine($"Name: {parts[1]}");
                Console.WriteLine($"Doctor ID: {parts[2]}");
                break;
            }
        }
        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    static void ListMyDoctorDetails(string id, string patientsDetailFile, string doctorsDetailFile)
    {
        string doctorId = "";
        bool foundPatient = false;

        foreach (var line in File.ReadLines(patientsDetailFile))
        {
            var parts = line.Split(',');
            if (parts.Length > 2 && parts[0] == id)
            {
                doctorId = parts[2];
                foundPatient = true;
                break;
            }
        }

        if (foundPatient)
        {
            foreach (var line in File.ReadLines(doctorsDetailFile))
            {
                var parts = line.Split(',');
                if (parts.Length > 3 && parts[0] == doctorId)
                {
                    Console.WriteLine($"Doctor ID: {parts[0]}");
                    Console.WriteLine($"Name: {parts[1]}");
                    Console.WriteLine($"Specialty: {parts[2]}");
                    Console.WriteLine($"Contact: {parts[3]}");
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }

        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    static void BookAppointment(string id, string patientsDetailFile, string doctorsDetailFile, string appointmentsFile)
    {
        Console.Write("Enter Doctor ID: ");
        string doctorId = Console.ReadLine();
        Console.Write("Enter Date (YYYY-MM-DD): ");
        string date = Console.ReadLine();

        if (IsInFile(doctorId, doctorsDetailFile))
        {
            string appointmentDetails = $"{id},{doctorId},{date}";
            File.AppendAllText(appointmentsFile, appointmentDetails + Environment.NewLine);
            Console.WriteLine("Appointment booked successfully.");
        }
        else
        {
            Console.WriteLine("Invalid Doctor ID.");
        }

        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    static void ListAppointments(string appointmentsFile)
    {
        Console.WriteLine("Appointments:");
        foreach (var line in File.ReadLines(appointmentsFile))
        {
            var parts = line.Split(',');
            if (parts.Length == 3)
            {
                Console.WriteLine($"Patient ID: {parts[0]}, Doctor ID: {parts[1]}, Date: {parts[2]}");
            }
        }
        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    static void ListDoctorDetails(string id, string doctorsDetailFile)
    {
        foreach (var line in File.ReadLines(doctorsDetailFile))
        {
            var parts = line.Split(',');
            if (parts.Length > 3 && parts[0] == id)
            {
                Console.WriteLine($"Doctor ID: {parts[0]}");
                Console.WriteLine($"Name: {parts[1]}");
                Console.WriteLine($"Specialty: {parts[2]}");
                Console.WriteLine($"Contact: {parts[3]}");
                break;
            }
        }
        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    static void ListPatients(string patientsDetailFile, string doctorsDetailFile)
    {
        Console.WriteLine("Patients:");
        foreach (var line in File.ReadLines(patientsDetailFile))
        {
            var parts = line.Split(',');
            if (parts.Length > 2)
            {
                Console.WriteLine($"Patient ID: {parts[0]}, Name: {parts[1]}, Doctor ID: {parts[2]}");
            }
        }
        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    static void CheckParticularPatient(string patientsDetailFile)
    {
        Console.Write("Enter Patient ID: ");
        string patientId = Console.ReadLine();

        foreach (var line in File.ReadLines(patientsDetailFile))
        {
            var parts = line.Split(',');
            if (parts.Length > 2 && parts[0] == patientId)
            {
                Console.WriteLine($"Patient ID: {parts[0]}");
                Console.WriteLine($"Name: {parts[1]}");
                Console.WriteLine($"Doctor ID: {parts[2]}");
                break;
            }
        }
        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    static void ListAppointmentsWithPatient(string id, string appointmentsFile)
    {
        Console.WriteLine("Appointments with Patient:");
        foreach (var line in File.ReadLines(appointmentsFile))
        {
            var parts = line.Split(',');
            if (parts.Length == 3 && parts[0] == id)
            {
                Console.WriteLine($"Doctor ID: {parts[1]}, Date: {parts[2]}");
            }
        }
        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    static void ListAllDoctors(string doctorsDetailFile)
    {
        Console.WriteLine("All Doctors:");
        foreach (var line in File.ReadLines(doctorsDetailFile))
        {
            var parts = line.Split(',');
            if (parts.Length > 3)
            {
                Console.WriteLine($"Doctor ID: {parts[0]}, Name: {parts[1]}, Specialty: {parts[2]}, Contact: {parts[3]}");
            }
        }
        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    static void CheckDoctorDetails(string doctorsDetailFile)
    {
        Console.Write("Enter Doctor ID: ");
        string doctorId = Console.ReadLine();

        foreach (var line in File.ReadLines(doctorsDetailFile))
        {
            var parts = line.Split(',');
            if (parts.Length > 3 && parts[0] == doctorId)
            {
                Console.WriteLine($"Doctor ID: {parts[0]}");
                Console.WriteLine($"Name: {parts[1]}");
                Console.WriteLine($"Specialty: {parts[2]}");
                Console.WriteLine($"Contact: {parts[3]}");
                break;
            }
        }
        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    static void ListAllPatients(string patientsDetailFile)
    {
        Console.WriteLine("All Patients:");
        foreach (var line in File.ReadLines(patientsDetailFile))
        {
            var parts = line.Split(',');
            if (parts.Length > 2)
            {
                Console.WriteLine($"Patient ID: {parts[0]}, Name: {parts[1]}, Doctor ID: {parts[2]}");
            }
        }
        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    static void CheckPatientDetails(string patientsDetailFile)
    {
        Console.Write("Enter Patient ID: ");
        string patientId = Console.ReadLine();

        foreach (var line in File.ReadLines(patientsDetailFile))
        {
            var parts = line.Split(',');
            if (parts.Length > 2 && parts[0] == patientId)
            {
                Console.WriteLine($"Patient ID: {parts[0]}");
                Console.WriteLine($"Name: {parts[1]}");
                Console.WriteLine($"Doctor ID: {parts[2]}");
                break;
            }
        }
        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }

    static void AddPatient(string patientsDetailFile)
    {
        Console.Write("Enter Patient ID: ");
        string id = Console.ReadLine();
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Doctor ID: ");
        string doctorId = Console.ReadLine();

        string newPatient = $"{id},{name},{doctorId}";
        File.AppendAllText(patientsDetailFile, newPatient + Environment.NewLine);
        Console.WriteLine("Patient added successfully.");
        Console.WriteLine("Press any key to return to menu.");
        Console.ReadKey();
    }
}

