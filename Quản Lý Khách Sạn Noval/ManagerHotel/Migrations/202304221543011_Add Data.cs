namespace ManagerHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RoomTypes(Name, Description) VALUES ('Standard', 'Standard room')");
            Sql("INSERT INTO RoomTypes(Name, Description) VALUES ('Single room', 'these rooms are assigned to one person or a couple')");
            Sql("INSERT INTO RoomTypes(Name, Description) VALUES ('Double room', 'double rooms are assigned to two people; expect one double bed, or two twin beds depending on the hotel.')");
            Sql("INSERT INTO RoomTypes(Name, Description) VALUES ('Quad room', 'a quad room is set up for four people to stay comfortably')");
            Sql("INSERT INTO RoomTypes(Name, Description) VALUES ('Deluxe room', 'these rooms might be a bit bigger with slightly upgraded amenities or a nicer view')");
            Sql("INSERT INTO RoomTypes(Name, Description) VALUES ('Penthouse', 'big rooms – sometimes taking up the entire top floor of a hotel – and come with the ultimate luxury amenities.')");

            Sql("INSERT INTO Rooms(RoomNumber, Description, Price, FloorNumber, Image, IsActive, IsAvailable, RoomTypeId) " +
                              "VALUES ('501', 'Standard room with single bed', 5500000, 5, 'https://res.cloudinary.com/dif0oia5b/image/upload/v1682174703/pent_udigve.jpg', 1, 1, " +
                              "(SELECT RoomTypeId FROM RoomTypes WHERE Name = 'Penthouse'))");
            Sql("INSERT INTO Rooms(RoomNumber, Description, Price, FloorNumber, Image, IsActive, IsAvailable, RoomTypeId) " +
                             "VALUES ('502', 'Standard room with single bed', 6000000, 5, 'https://res.cloudinary.com/dif0oia5b/image/upload/v1682174703/pent_udigve.jpg', 1, 1, " +
                             "(SELECT RoomTypeId FROM RoomTypes WHERE Name = 'Penthouse'))");
            Sql("INSERT INTO Rooms(RoomNumber, Description, Price, FloorNumber, Image, IsActive, IsAvailable, RoomTypeId) " +
                             "VALUES ('503', 'Standard room with single bed', 5000000, 5, 'https://res.cloudinary.com/dif0oia5b/image/upload/v1682174703/pent_udigve.jpg', 1, 1, " +
                             "(SELECT RoomTypeId FROM RoomTypes WHERE Name = 'Penthouse'))");

            Sql("INSERT INTO Rooms(RoomNumber, Description, Price, FloorNumber, Image, IsActive, IsAvailable, RoomTypeId) " +
                             "VALUES ('101', 'Standard room with single bed', 2000000, 1, 'https://res.cloudinary.com/dif0oia5b/image/upload/v1682174701/double_ctsmr9.jpg', 1, 1, " +
                             "(SELECT RoomTypeId FROM RoomTypes WHERE Name = 'Standard'))");
            Sql("INSERT INTO Rooms(RoomNumber, Description, Price, FloorNumber, Image, IsActive, IsAvailable, RoomTypeId) " +
                             "VALUES ('102', 'Standard room with single bed', 2000000, 1, 'https://res.cloudinary.com/dif0oia5b/image/upload/v1682174701/double_ctsmr9.jpg', 1, 1, " +
                             "(SELECT RoomTypeId FROM RoomTypes WHERE Name = 'Standard'))");
            Sql("INSERT INTO Rooms(RoomNumber, Description, Price, FloorNumber, Image, IsActive, IsAvailable, RoomTypeId) " +
                             "VALUES ('103', 'Standard room with single bed', 2000000, 1, 'https://res.cloudinary.com/dif0oia5b/image/upload/v1682174702/sign_n4w1uy.jpg', 1, 1, " +
                             "(SELECT RoomTypeId FROM RoomTypes WHERE Name = 'Single room'))");
            Sql("INSERT INTO Rooms(RoomNumber, Description, Price, FloorNumber, Image, IsActive, IsAvailable, RoomTypeId) " +
                             "VALUES ('104', 'Standard room with single bed', 2000000, 1, 'https://res.cloudinary.com/dif0oia5b/image/upload/v1682174702/sign_n4w1uy.jpg', 1, 1, " +
                             "(SELECT RoomTypeId FROM RoomTypes WHERE Name = 'Single room'))");

            Sql("INSERT INTO Rooms(RoomNumber, Description, Price, FloorNumber, Image, IsActive, IsAvailable, RoomTypeId) " +
                             "VALUES ('401', 'Standard room with single bed', 3500000, 1, 'https://res.cloudinary.com/dif0oia5b/image/upload/v1682174702/quad_wwbyq7.jpg', 1, 1, " +
                             "(SELECT RoomTypeId FROM RoomTypes WHERE Name = 'Quad room'))");
            Sql("INSERT INTO Rooms(RoomNumber, Description, Price, FloorNumber, Image, IsActive, IsAvailable, RoomTypeId) " +
                             "VALUES ('402', 'Standard room with single bed', 3000000, 1, 'https://res.cloudinary.com/dif0oia5b/image/upload/v1682174702/quad_wwbyq7.jpg', 1, 1, " +
                             "(SELECT RoomTypeId FROM RoomTypes WHERE Name = 'Quad room'))");
            Sql("INSERT INTO Rooms(RoomNumber, Description, Price, FloorNumber, Image, IsActive, IsAvailable, RoomTypeId) " +
                             "VALUES ('403', 'Standard room with single bed', 3000000, 1, 'https://res.cloudinary.com/dif0oia5b/image/upload/v1682174702/quad_wwbyq7.jpg', 1, 1, " +
                             "(SELECT RoomTypeId FROM RoomTypes WHERE Name = 'Quad room'))");

            Sql("INSERT INTO ServiceTypes(Name, Description) VALUES (N'Dịch vụ ăn uống', N'Cung cấp các dịch vụ ăn uống')");
            Sql("INSERT INTO ServiceTypes(Name, Description) VALUES (N'Dịch vụ giặt là', N'Cung cấp dịch vụ giặt là')");
            Sql("INSERT INTO ServiceTypes(Name, Description) VALUES (N'Dịch vụ xe đưa đón', N'Cung cấp dịch vụ xe đưa đón')");


        
    }
        
        public override void Down()
        {
        }
    }
}
