USE [DiversHotel]
GO

INSERT INTO [dbo].[RoomType]
           ([RoomTypeName])
     VALUES
           (N'Standard Room'),
           (N'Sea View Room'),
           (N'Royal Suite')
GO

INSERT INTO [dbo].[RoomTypePrice]
           ([RoomTypeId] ,[PricePerNight] ,[FromDateUtc] ,[ToDateUtc])
     VALUES
           (1, 80, '2021-01-01', '2021-01-15'),
           (1, 50, '2021-01-16', '2021-04-30'),
           (2, 120, '2021-01-01', '2021-01-15'),
           (2, 90, '2021-01-16', '2021-03-31'),
           (2, 100, '2021-04-01', '2021-04-30')
GO

INSERT INTO [dbo].[MealPlan]
           ([Name], [Description])
     VALUES
           (N'Half Board', NULL),
           (N'Full Board', NULL),
           (N'All Inclusive', NULL)
GO

INSERT INTO [dbo].[MealPlanPrice]
           ([MealPlanId] ,[PricePerPerson] ,[FromDateUtc] ,[ToDateUtc])
     VALUES
           (1, 5, '2021-01-01', '2021-05-31'),
           (1, 10, '2021-06-01', '2021-12-31'),
           (2, 20, '2021-01-01', '2021-05-31'),
           (2, 25, '2021-06-01', '2021-12-31'),
           (3, 25, '2021-01-01', '2021-05-31'),
           (3, 30, '2021-06-01', '2021-12-31')
GO


INSERT INTO [dbo].[Room]
           ([RoomNumber]
           ,[RoomTypeId]
     VALUES
           (N'A-01', 1),
		   (N'A-02', 1),
		   (N'B-01', 2)
GO
