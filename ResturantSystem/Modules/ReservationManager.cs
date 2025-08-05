using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResturantSystem.Modules
{
    public class ReservationManager
    {
       
            private List<Reservation> reservations;
            private const int TotalTables = 10;
            private const int ChairsPerTable = 5;
            private const string FilePath = "C:\\Users\\USER\\source\\repos\\ResturantSystem\\ResturantSystem\\OurData\\resevations.txt"; // عدل المسار حسب جهازك

            public ReservationManager()
            {
                reservations = LoadReservationsFromFile();
            }

            public void MakeReservation()
            {
                Console.Write("👤 Enter your name: ");
                string name = Console.ReadLine();

                int requestedTables;
                Console.Write("🔢 Enter number of tables needed: ");
                while (!int.TryParse(Console.ReadLine(), out requestedTables) || requestedTables <= 0)
                {
                    Console.Write("❌ Invalid number. Please enter a positive number: ");
                }

                DateTime reservationTime;
                Console.Write("⏰ Enter reservation time (e.g., 2025-08-02 19:00): ");
                while (!DateTime.TryParse(Console.ReadLine(), out reservationTime))
                {
                    Console.Write("❌ Invalid format. Try again (e.g., 2025-08-02 19:00): ");
                }

                int reservedTablesAtTime = reservations
                    .Where(r => r.ReservationTime == reservationTime)
                    .Sum(r => r.TableCount);

                int availableTables = TotalTables - reservedTablesAtTime;

                if (requestedTables > availableTables)
                {
                    Console.WriteLine($"\n❌ Not enough tables available at that time.");
                    Console.WriteLine($"🪑 Available tables: {availableTables} out of {TotalTables}");
                    return;
                }

                var reservation = new Reservation
                {
                    ReservationId = reservations.Count > 0 ? reservations.Max(r => r.ReservationId) + 1 : 1,
                    CustomerName = name,
                    TableCount = requestedTables,
                    ChairCount = requestedTables * ChairsPerTable,
                    ReservationTime = reservationTime
                };

                reservations.Add(reservation);
                SaveReservationsToFile();

                Console.WriteLine("\n✅ Reservation confirmed:");
                Console.WriteLine(reservation);
            }

            public void ViewAllReservations()
            {
                Console.WriteLine("\n📋 All Reservations:");
                reservations = LoadReservationsFromFile();

                if (reservations.Count == 0)
                {
                    Console.WriteLine("❌ No reservations found.");
                    return;
                }

                foreach (var res in reservations)
                {
                    Console.WriteLine(res);
                }
            }

            public void CancelReservation(int id)
            {
                var reservation = reservations.FirstOrDefault(r => r.ReservationId == id);
                if (reservation != null)
                {
                    reservations.Remove(reservation);
                    SaveReservationsToFile();
                    Console.WriteLine("✅ Reservation cancelled.");
                }
                else
                {
                    Console.WriteLine("❌ Reservation not found.");
                }
            }

            private void SaveReservationsToFile()
            {
                var lines = reservations.Select(r =>
                    $"{r.ReservationId}|{r.CustomerName}|{r.TableCount}|{r.ChairCount}|{r.ReservationTime}");

                File.WriteAllLines(FilePath, lines);
            }

            private List<Reservation> LoadReservationsFromFile()
            {
                var list = new List<Reservation>();

                if (!File.Exists(FilePath))
                    return list;

                var lines = File.ReadAllLines(FilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 5 &&
                        int.TryParse(parts[0], out int id) &&
                        int.TryParse(parts[2], out int tables) &&
                        int.TryParse(parts[3], out int chairs) &&
                        DateTime.TryParse(parts[4], out DateTime time))
                    {
                        list.Add(new Reservation
                        {
                            ReservationId = id,
                            CustomerName = parts[1],
                            TableCount = tables,
                            ChairCount = chairs,
                            ReservationTime = time
                        });
                    }
                }

                return list;
            }
        }
    }


    

