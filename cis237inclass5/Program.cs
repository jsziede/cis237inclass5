using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass5
{
    class Program
    {
        static void Main(string[] args)
        {
            //make a new instance of the cars collection
            CarsJSziedeEntities carsJSziedeEntities = new CarsJSziedeEntities();

            //*************************************
            //List out all of the cars in the table
            //*************************************
            Console.WriteLine("Print the list");

            foreach (Car car in carsJSziedeEntities.Cars)
            {
                Console.WriteLine(car.id + " " + car.make + " " + car.model);
            }

            //=====================================
            //find a specfic one by any property
            //=====================================

            //Call the where method on the table Cars and pass in a lambda expression
            //for the criteria we are looking for. there is nothing special about the word
            //car in the part that reads: car => car.id == "V0LCD1418." It could be any character we
            //want it to be. it is just a variable name for the current car we are ocnsidering in the expression
            //this will automatically loop through all the cars, and run the expression against each of them.
            //when the result if finally true, it will return that car
            Car carIDToFind = carsJSziedeEntities.Cars.Where(car => car.id == "V0LCD1814").First();

            //we can look for a specific model from the database with a where clause based on any criteria we want
            //we can narrow it down. here we are doing it with the car's model instead of its ID
            Car carModelToFind = carsJSziedeEntities.Cars.Where(car => car.model == "Challenger").First();

            //print them out
            Console.WriteLine(carIDToFind.id + " " + carIDToFind.make + " " + carIDToFind.model);
            Console.WriteLine();
            Console.WriteLine(carModelToFind.id + " " + carModelToFind.make + " " + carModelToFind.model);
            Console.WriteLine();

            //find by primary key (car ID = primary key)
            //pull out a car from the table based on the id
            Car foundCar = carsJSziedeEntities.Cars.Find("V0LCD1814");

            Console.WriteLine(foundCar.id + " " + foundCar.make + " " + foundCar.model);

            //MAKE A NEW INSTANCE OF A CAR
            Car newCarToAdd = new Car();

            //assign properties to the parts of the model
            newCarToAdd.id = "8888";
            newCarToAdd.make = "Nissan";
            newCarToAdd.model = "GT-R";
            newCarToAdd.horsepower = 550;
            newCarToAdd.cylinders = 8;
            newCarToAdd.year = "2016";
            newCarToAdd.type = "Car";

            carsJSziedeEntities.Cars.Add(newCarToAdd);
            carsJSziedeEntities.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("A new car was added.");
            foundCar = carsJSziedeEntities.Cars.Find("8888");
            Console.WriteLine(foundCar.id + " " + foundCar.make + " " + foundCar.model);

            //update ===========================================================================================
            //get a car out of the database that we would like to update
            Car carToUpdate = carsJSziedeEntities.Cars.Find("8888");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("is update time");
            Console.WriteLine(carToUpdate.id + " " + carToUpdate.make + " " + carToUpdate.model);

            //update some of the properties of the car we found. don't need to
            //update all of them if we dont want to. i chose these 4
            carToUpdate.make = "Nissan";
            carToUpdate.model = "GT-AYY-LMAO";
            carToUpdate.horsepower = 1234;
            carToUpdate.cylinders = 16;

            //save changes to the database
            carsJSziedeEntities.SaveChanges();
            carToUpdate = carsJSziedeEntities.Cars.Find("8888");
            Console.WriteLine(carToUpdate.id + " " + carToUpdate.make + " " + carToUpdate.model);

            //delete ==========================================================================================
            Car carToDelete = carsJSziedeEntities.Cars.Find("8888");

            //remove the car
            carsJSziedeEntities.Cars.Remove(carToDelete);
            carsJSziedeEntities.SaveChanges();
        }
    }
}
