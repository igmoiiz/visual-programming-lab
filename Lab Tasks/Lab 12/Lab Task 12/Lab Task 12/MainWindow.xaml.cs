using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;

namespace Lab_Task_12
{
	public partial class MainWindow : Window
	{
		// Data models representing database tables
		public class Appointment
		{
			public int AID { get; set; }
			public int PID { get; set; }
			public int DID { get; set; }
			public DateTime AppointmentDate { get; set; }
			public TimeSpan AppointmentTime { get; set; }
			public Patient Patient { get; set; }
			public Doctor Doctor { get; set; }
		}

		public class Patient
		{
			public int PID { get; set; }
			public string Name { get; set; }
			public string Address { get; set; }
			public string ContactNo { get; set; }
		}

		public class Doctor
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string Designation { get; set; }
			public string Specialization { get; set; }
		}

		public MainWindow()
		{
			InitializeComponent();

			// Simulated database data
			var patients = new List<Patient>
			{
				new Patient { PID = 1, Name = "John Doe", Address = "123 Main Street", ContactNo = "123456789" },
				new Patient { PID = 2, Name = "Jane Smith", Address = "456 Elm Street", ContactNo = "987654321" }
			};

			var doctors = new List<Doctor>
			{
				new Doctor { Id = 1, Name = "Dr. Adams", Designation = "Surgeon", Specialization = "Orthopedics" },
				new Doctor { Id = 2, Name = "Dr. Brown", Designation = "Physician", Specialization = "General Medicine" }
			};

			var appointments = new List<Appointment>
			{
				new Appointment
				{
					AID = 1, PID = 1, DID = 1,
					AppointmentDate = DateTime.Now.Date,
					AppointmentTime = new TimeSpan(10, 30, 0),
					Patient = patients.First(p => p.PID == 1),
					Doctor = doctors.First(d => d.Id == 1)
				},
				new Appointment
				{
					AID = 2, PID = 2, DID = 2,
					AppointmentDate = DateTime.Now.Date.AddDays(1),
					AppointmentTime = new TimeSpan(11, 45, 0),
					Patient = patients.First(p => p.PID == 2),
					Doctor = doctors.First(d => d.Id == 2)
				}
			};

			// LINQ Query: Navigation Technique
			var appointmentList = (from a in appointments
								   select new
								   {
									   AppointmentID = a.AID,
									   PatientName = a.Patient.Name,
									   DoctorName = a.Doctor.Name,
									   AppointmentDate = a.AppointmentDate.ToString("yyyy-MM-dd"),
									   AppointmentTime = a.AppointmentTime.ToString(@"hh\:mm")
								   }).ToList();

			// Binding the query result to the DataGrid
			AppointmentDataGrid.ItemsSource = appointmentList;
		}
	}
}