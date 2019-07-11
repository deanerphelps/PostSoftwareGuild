use [master]
GO

if exists (select * from sys.databases where name = N'HotelReservation')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'HotelReservation';
	ALTER DATABASE HotelReservation SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE HotelReservation;
end
Create Database HotelReservation
Use HotelReservation

Create Table Rooms (IDRoom int primary key identity(1,1) Not Null,
					RoomNumber int Not Null,
					IDRoomType int Not Null,
					ADAStatus bit Not Null)


Create Table RoomTypes (IDRoomType int primary key identity(1,1) Not Null,
					RoomTypeName varchar(50) Not Null,
					IDAmentity int Not Null,
					StandardOccupancy int Not Null,
					MaxOccupancy int Not Null,
					RoomPrice decimal(8,2) Not Null)


Create Table Amentities (IDAmentity int primary key identity(1,1) Not Null,
					AmentityType varchar(50) Not Null,
					AmentityCost decimal(4,2) Null)


Create Table Reservations (IDReservation int primary key identity(1,1) Not Null,
					IDRoom int Not Null,
					IDGuest int Not Null,
					AdultCount int Not Null,
					ChildCount int Null,
					StartDate date Not Null,
					EndDate date Not Null,
					TotalRoomCost decimal(8,2) Not Null)


Create Table Guests (IDGuest int primary key identity(1,1) Not Null,
					GuestFName varchar(50) Not Null,
					GuestLName varchar(50) Not Null,
					Address varchar(100) Not Null,
					City varchar(100) Not Null,
					State varchar(25) Not Null,
					Zip varchar(10) Not Null,
					Phone varchar(25) Not Null)

GO
