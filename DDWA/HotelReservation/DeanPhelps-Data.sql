Use HotelReservation

insert into Rooms (
	RoomNumber,
	IDRoomType,
    ADAStatus
) values
(201,4,0),
(202,3,1),
(203,4,0),
(204,3,1),
(205,2,0),
(206,1,1),
(207,2,0),
(208,1,1),
(301,4,0),
(302,3,1),
(303,4,0),
(304,3,1),
(305,2,0),
(306,1,1),
(307,2,0),
(308,1,1),
(401,5,1),
(402,5,1);

insert into RoomTypes (
	RoomTypeName,
	IDAmentity,
    StandardOccupancy,
	MaxOccupancy,
	RoomPrice
) values
('Single',4,2,2,$149.99),
('Single',3,2,2,$174.99),
('Double',2,2,4,$174.99),
('Double',1,2,4,$199.99),
('Suite',5,3,8,$399.99);

insert into Amentities(
	AmentityType,
    AmentityCost
) values
('Microwave, Jacuzzi',$25),
('Refrigerator',Null),
('Microwave, Refrigerator, Jacuzzi 	',$25),
('Microwave, Refrigerator',Null),
('Microwave, Refrigerator, Oven',Null);

insert into Reservations(
	IDRoom,
    IDGuest,
	AdultCount,
	ChildCount,
	StartDate,
	EndDate,
	TotalRoomCost
) values				
(16,2,1,0, '02/02/2023', '02/04/2023',$299.98),
(3,3,2,1, '02/05/2023', '02/10/2023', $999.95),
(13,4,2,0, '2/22/2023', '2/24/2023', $349.98),
(1,5,2,2, '3/6/2023', '3/7/2023', $199.99),
(15,1,1,1,'3/17/2023', '3/20/2023', $524.97),
(10,6,3,0, '3/18/2023', '3/23/2023', $924.95),
(2,7,2,2, '3/29/2023', '3/31/2023',$349.98),
(12,8,2,0, '3/31/2023', '4/5/2023', $874.95),
(9,9,1,0, '4/9/2023', '4/13/2023', $799.96),
(7,10,1,1, '4/23/2023', '4/24/2023', $174.99),
(17,11,2,4, '5/30/2023', '6/2/2023', $1199.97),
(6,12,2,0, '6/10/2023', '6/14/2023',$599.96),
(8,12,1,0, '6/10/2023', '6/14/2023', $599.96),
(12,6,3,0, '6/17/2023', '6/18/2023',$184.99),
(5,1,2,0, '6/28/2023','7/2/2023',$699.96),
(4,9,3,1, '7/13/2023', '7/14/2023', $184.99),
(17,10,4,2, '7/18/2023', '7/21/2023',$1259.97),
(11,3,2,1, '7/28/2023', '7/29/2023', $199.99),
(13,3,1,0, '8/30/2023', '9/1/2023', $349.98),
(8,2,2,0, '9/16/2023', '9/17/2023', $149.99),
(3,5,2,2, '9/13/2023', '9/15/2023', $399.98),
(17,4,2,2, '11/22/2023', '11/25/2023', $1199.97),
(6,2,2,0, '11/22/2023', '11/25/2023', $449.97),
(9,2,2,2, '11/22/2023', '11/25/2023', $599.97),
(10,11,2,0, '12/24/2023', '12/28/2023', $699.96);

insert into Guests (
	GuestFName,
	GuestLName,
    Address,
	City,
	State,
	Zip,
	Phone
) values
('Dean', 'Phelps','2200 Baker St','Louisville','KY','40220','(502) 867-5309'),
('Mack', 'Simmer','379 Old Shore Street','Council Bluffs','IA','51501','(291) 553-0508'),
('Bettyann', ' Seery','750 Wintergreen Dr.','Wasilla','AK','99654','(478) 277-9632'),
('Duane', ' Cullison','9662 Foxrun Lane','Harlingen','TX','78552','(308) 494-0198'),
('Karie', ' Yang','9378 W. Augusta Ave.','West Deptford','NJ','08096','(214) 730-0298'),
('Aurore', ' Lipton','762 Wild Rose Street','Saginaw','MI','48601','(377) 507-0974'),
('Zachery', ' Luechtefeld','7 Poplar Dr.','Arvada','CO','80003','(814) 485-2615'),
('Jeremiah', ' Pendergrass','70 Oakwood St.','Zion','IL','60099','(279) 491-0960'),
('Walter', ' Holaway','7556 Arrowhead St.','Cumberland','RI','02864','(446) 396-6785'),
('Wilfred', ' Vise','77 West Surrey Street','Oswego','NY','13126','(834) 727-1001'),
('Maritza', ' Tilton','939 Linda Rd.','Burke','VA','22015','(446) 351-6860'),
('Joleen', ' Tison','87 Queen St.','Drexel Hill','PA','19026','(231) 893-2755');

Delete From Reservations 
Where IDGuest like '8'
Delete From Guests
Where GuestFName like 'Jeremiah'
