Use HotelReservation

--1
Select Guests.GuestFName, Guests.GuestLName, Rooms.RoomNumber, Reservations.EndDate
From Reservations
	Join Guests ON Guests.IDGuest=Reservations.IDGuest
	Join Rooms ON Rooms.IDRoom=Reservations.IDRoom
Where EndDate like '2023-07%'

Dean	Phelps	205	2023-07-02
Walter	 Holaway	204	2023-07-14
Wilfred	 Vise	401	2023-07-21
Bettyann	 Seery	303	2023-07-29

--2
Select Guests.GuestFName, Guests.GuestLName, Rooms.RoomNumber, Amentities.AmentityType, Reservations.StartDate, Reservations.EndDate
From Reservations
	Join Guests ON Guests.IDGuest=Reservations.IDGuest
	Join Rooms ON Rooms.IDRoom=Reservations.IDRoom
	Join Amentities ON Amentities.IDAmentity=Reservations.IDRoom
Where AmentityType like '%Jacuzzi%'

Bettyann	 Seery	203	Microwave, Refrigerator, Jacuzzi  	2023-02-05	2023-02-10
Karie	 Yang	201	Microwave, Jacuzzi	2023-03-06	2023-03-07
Karie	 Yang	203	Microwave, Refrigerator, Jacuzzi  	2023-09-13	2023-09-15

--3
Select Guests.GuestFName, Guests.GuestLName, Rooms.RoomNumber, Reservations.StartDate, Reservations.AdultCount, Reservations.ChildCount
From Reservations
	Join Guests on Reservations.IDGuest=Guests.IDGuest
	Join Rooms on Rooms.IDRoom=Reservations.IDRoom
Where GuestFName like 'Dean'

Dean	Phelps	307	2023-03-17	1	1
Dean	Phelps	205	2023-06-28	2	0

--4
Select Rooms.RoomNumber, Reservations.IDReservation, Reservations.TotalRoomCost
From Reservations
	Full Outer Join Rooms on Rooms.IDRoom=Reservations.IDRoom
Order by RoomNumber

201	4	199.99
202	7	349.98
203	2	999.95
203	21	399.98
204	16	184.99
205	15	699.96
206	23	449.97
206	12	599.96
207	10	174.99
208	13	599.96
208	20	149.99
301	24	599.97
301	9	799.96
302	6	924.95
302	25	699.96
303	18	199.99
304	14	184.99
305	19	349.98
305	3	349.98
306	NULL	NULL
307	5	524.97
308	1	299.98
401	17	1259.97
401	11	1199.97
401	22	1199.97
402	NULL	NULL

--5
Select Rooms.RoomNumber
From Reservations
	Join Rooms on Rooms.IDRoom=Reservations.IDRoom
Where StartDate like '2023-04%' and  (AdultCount+ChildCount > 3)

--There aren't any

--6
Select Guests.GuestFName, Guests.GuestLName, Reservations.IDReservation
From Reservations
	Join Guests on Guests.IDGuest=Reservations.IDGuest
Order by GuestLName

Duane	 Cullison	3
Duane	 Cullison	22
Walter	 Holaway	9
Walter	 Holaway	16
Aurore	 Lipton	6
Aurore	 Lipton	14
Zachery	 Luechtefeld	7
Bettyann	 Seery	2
Bettyann	 Seery	18
Bettyann	 Seery	19
Maritza	 Tilton	11
Maritza	 Tilton	25
Joleen	 Tison	12
Joleen	 Tison	13
Wilfred	 Vise	10
Wilfred	 Vise	17
Karie	 Yang	4
Karie	 Yang	21
Dean	Phelps	5
Dean	Phelps	15
Mack	Simmer	1
Mack	Simmer	20
Mack	Simmer	23
Mack	Simmer	24

--7
Select GuestFName, GuestLName, Address, Phone
From Guests
Where Phone like '(502) 867-5309'

Dean	Phelps	2200 Baker St	(502) 867-5309