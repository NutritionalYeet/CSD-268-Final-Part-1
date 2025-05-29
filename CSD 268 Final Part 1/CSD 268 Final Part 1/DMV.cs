using System;
namespace CSD_268_Final_Part_1
{
	/// <summary>
	/// Department of Motor Vehicles.
	/// Contains the "CanDrive" method.
	/// </summary>
	public class DMV {

		/// <summary>
		/// Determines whether a person of a given age is able to drive.
		/// Assumes the given age is that of a human.
		/// </summary>
		/// <param name="age">The potential driver's age</param>
		/// <returns>Whether the provided age is at least 16.</returns>
		public bool CanDrive (int age)
				{

					const int drivingAge = 16; 

					return age >= drivingAge;

				}
	}
}

