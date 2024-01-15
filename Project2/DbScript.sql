

USE [master]
GO

DROP DATABASE IF EXISTS [estateagent]
GO

CREATE DATABASE [estateagent]
GO

USE [estateagent]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booking](
	[BOOKING_ID] [int] IDENTITY(1,1) NOT NULL,
	[BUYER_ID] [int] NOT NULL,
	[PROPERTY_ID] [int] NOT NULL,
	[TIME] [datetime] NULL,
 CONSTRAINT [PK_booking_BOOKING_ID] PRIMARY KEY CLUSTERED 
(
	[BOOKING_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[buyer](
	[BUYER_ID] [int] IDENTITY(1,1) NOT NULL,
	[FIRST_NAME] [nvarchar](255) NOT NULL,
	[SURNAME] [nvarchar](255) NOT NULL,
	[ADDRESS] [nvarchar](255) NOT NULL,
	[POSTCODE] [nvarchar](255) NOT NULL,
	[PHONE] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_buyer_BUYER_ID] PRIMARY KEY CLUSTERED 
(
	[BUYER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[property](
	[PROPERTY_ID] [int] IDENTITY(1,1) NOT NULL,
	[ADDRESS] [nvarchar](255) NOT NULL,
	[POSTCODE] [nvarchar](255) NOT NULL,
	[TYPE] [nvarchar](9) NOT NULL,
	[NUMBER_OF_BEDROOMS] [int] NOT NULL,
	[NUMBER_OF_BATHROOMS] [int] NOT NULL,
	[GARDEN] [binary](1) NOT NULL,
	[PRICE] [decimal](11, 2) NULL,
	[STATUS] [nvarchar](9) NOT NULL,
	[SELLER_ID] [int] NOT NULL,
	[BUYER_ID] [int] NULL,
 CONSTRAINT [PK_property_PROPERTY_ID] PRIMARY KEY CLUSTERED 
(
	[PROPERTY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seller](
	[SELLER_ID] [int] IDENTITY(1,1) NOT NULL,
	[FIRST_NAME] [nvarchar](255) NOT NULL,
	[SURNAME] [nvarchar](255) NOT NULL,
	[ADDRESS] [nvarchar](255) NOT NULL,
	[POSTCODE] [nvarchar](255) NOT NULL,
	[PHONE] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_seller_SELLER_ID] PRIMARY KEY CLUSTERED 
(
	[SELLER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[booking] ADD  DEFAULT (NULL) FOR [TIME]
GO
ALTER TABLE [dbo].[property] ADD  DEFAULT (NULL) FOR [PRICE]
GO
ALTER TABLE [dbo].[property] ADD  DEFAULT (NULL) FOR [BUYER_ID]
GO
ALTER TABLE [dbo].[booking]  WITH NOCHECK ADD  CONSTRAINT [booking$booking_ibfk_1] FOREIGN KEY([BUYER_ID])
REFERENCES [dbo].[buyer] ([BUYER_ID])
GO
ALTER TABLE [dbo].[booking] CHECK CONSTRAINT [booking$booking_ibfk_1]
GO
ALTER TABLE [dbo].[booking]  WITH NOCHECK ADD  CONSTRAINT [booking$booking_ibfk_2] FOREIGN KEY([PROPERTY_ID])
REFERENCES [dbo].[property] ([PROPERTY_ID])
GO
ALTER TABLE [dbo].[booking] CHECK CONSTRAINT [booking$booking_ibfk_2]
GO
ALTER TABLE [dbo].[property]  WITH NOCHECK ADD  CONSTRAINT [property$property_ibfk_1] FOREIGN KEY([SELLER_ID])
REFERENCES [dbo].[seller] ([SELLER_ID])
GO
ALTER TABLE [dbo].[property] CHECK CONSTRAINT [property$property_ibfk_1]
GO
ALTER TABLE [dbo].[property]  WITH NOCHECK ADD  CONSTRAINT [property$property_ibfk_2] FOREIGN KEY([BUYER_ID])
REFERENCES [dbo].[buyer] ([BUYER_ID])
GO
ALTER TABLE [dbo].[property] CHECK CONSTRAINT [property$property_ibfk_2]
GO


Insert into dbo.seller values('John', 'Doe', '1 High Street, Cardiff', 'CF1 1AA', '01234567890')
Insert into dbo.seller values('Anna', 'Smith', '2 High Street, Cardiff', 'CF1 1AB', '01234567891')
Insert into dbo.seller values('Peter', 'Jones', '3 Low Street, Cardiff', 'CF1 1AC', '01234567892')
Insert into dbo.seller values('Karen', 'Slayter', '4 High Street, Cardiff', 'CF1 1AD', '01234567893')
Insert into dbo.seller values('Jade', 'Huang', '5 Main Street, Beijing', '100 001', '01234567894')
Insert into dbo.seller values('Andy', 'Smith', '6 Broad Street, Cardiff', 'CF1 1AE', '01234567895')
Insert into dbo.seller values('Sarah', 'Miller', '7 High Street, Swansea', 'SA1 1AF', '01234567896')
Insert into dbo.seller values('Chris', 'Roberts', '8 Main Street, Cardiff', 'CF1 1AG', '01234567897')
Insert into dbo.seller values('Lucy', 'Brown', '9 Low Street, Cardiff', 'CF1 1AH', '01234567898')
Insert into dbo.seller values('Tom', 'Taylor', '10 High Street, Cardiff', 'CF1 1AI', '01234567899')
Insert into dbo.seller values('Sophie', 'Williams', '11 Main Street, Cardiff', 'CF1 1AJ', '01234567810')
Insert into dbo.seller values('David', 'Evans', '12 Low Street, Cardiff', 'CF1 1AK', '01234567811')
Insert into dbo.seller values('Emma', 'Clark', '13 Broad Street, Cardiff', 'CF1 1AL', '01234567812')
Insert into dbo.seller values('Mark', 'White', '14 High Street, Cardiff', 'CF1 1AM', '01234567813')
Insert into dbo.seller values('Oliva', 'Lee', '15 Main Street, Cardiff', 'CF1 1AN', '01234567814')

Insert into dbo.buyer values('Alice', 'Johnson', '42 Pen-y-lan Road, Cardiff', 'CA1 8RR', '01234567890')
Insert into dbo.buyer values('David', 'Williams', '100 Magnor Road, Newport', 'NP1 2LL 8RR', '01234567891')
Insert into dbo.buyer values('Sophie', 'Clark', 'Very Rich Street, London', 'W1', '01234567892')
Insert into dbo.buyer values('Oliver', 'Smith', '24 Meadow Lane, Bristol', 'BS1	3AB', '01234567893')
Insert into dbo.buyer values('Emily', 'Taylor', '5 Woodland Way, Manchester', 'M1 4XY', '01234567894')
Insert into dbo.buyer values('Charlotte', 'Brown', '8 Coral Street, Brighton', 'BN1 7ZZ', '01234567895')
Insert into dbo.buyer values('Jack', 'Miller', '10 Park Lane, Edinburgh', 'EH1 9FG', '01234567896')
Insert into dbo.buyer values('Sophia', 'Jones', '15 Cheese Street, Glasgow', 'G1 5RE', '01234567897')
Insert into dbo.buyer values('James', 'Roberts', '3 Catnip Close, Liverpool', 'L1 2CD', '01234567898')
Insert into dbo.buyer values('Grace', 'Turner', '12 Burrow Avenue, Nottingham', 'NG1 6EF', '01234567899')
Insert into dbo.buyer values('William', 'Hill', '7 Paw Prints Street, Leeds', 'LS1 8GH', '01234567810')
Insert into dbo.buyer values('Ava', 'Evans', '22 Feather Lane, Newcastle', 'NE1 3PW', '01234567811')
Insert into dbo.buyer values('Liam', 'White', '2 Yarn Road, Southampton', 'SO1 4KN', '01234567812')
Insert into dbo.buyer values('Ella', 'Horse', '18 Stable Street, Cambridge', 'CB1 2HS', '01234567813')
Insert into dbo.buyer values('Noah', 'Lee', '9 Whisker Way, Oxford', 'OX1 1PA', '01234567814')

Insert into dbo.property values('34 OK Place, OK Town','OK1 OK', 'DETACHED',3,1,0,100000,'FOR SALE', 13, NULL)
Insert into dbo.property values('22 Maple Street, Maple City','MC1 1MC', 'SEMI',4,2,0,150000,'FOR SALE',7,NULL)
Insert into dbo.property values('8 Rose Street, Roseville','RV1 2RV', 'APARTMENT',2,1,0,120000,'WITHDRAWN',14, NULL)
Insert into dbo.property values('15 Elm Street, Elmville','EV1 1EV', 'DETACHED',4,2,1,180000,'FOR SALE',4, NULL)
Insert into dbo.property values('3 Oak Street, Oakton','OT1 1OT', 'DETACHED',3,1,1,160000,'WITHDRAWN', 2, NULL)
Insert into dbo.property values('10 Pine Street, Pinewood','PW1 1PW', 'APARTMENT',2,1,0,130000,'FOR SALE', 6, NULL)
Insert into dbo.property values('7 Birch Street, Birchville','BV1 1BV', 'APARTMENT',3,2,1,170000,'SOLD', 3, 12)
Insert into dbo.property values('29 Cedar Street, Cedartown','CT1 1CT', 'DETACHED',5,3,1,200000,'FOR SALE', 8, NULL)
Insert into dbo.property values('12 Willow Street, Willowvale','WV1 1WV', 'APARTMENT',2,1,0,140000,'SOLD', 10,6)
Insert into dbo.property values('18 Fir Street, Firfield','FF1 1FF', 'SEMI',4,2,1,180000,'FOR SALE',  14, NULL)
Insert into dbo.property values('5 Redwood Street, Redwood City','RC1 1RC', 'DETACHED',5,3,1,220000,'SOLD', 11, 4)
Insert into dbo.property values('18 Fir Street, Firfield','FF1 1FF', 'SEMI',4,2,1,150000,'SOLD', 1, 10)


Insert into dbo.booking values(8, 12,'2023-03-03T15:45:00') 
Insert into dbo.booking values(6, 2,'2023-03-05T15:45:00') 
Insert into dbo.booking values(7,4,'2023-03-03T14:30:00') 
Insert into dbo.booking values(8, 6,'2023-03-04T09:00:00') 
Insert into dbo.booking values(10, 5,'2023-03-05T11:30:00') 
Insert into dbo.booking values(12, 7,'2023-03-06T14:45:00') 
Insert into dbo.booking values(13, 8,'2023-03-07T16:30:00') 
Insert into dbo.booking values(7, 9,'2023-03-08T12:00:00') 
Insert into dbo.booking values(11, 6,'2023-03-09T09:15:00') 
Insert into dbo.booking values(13, 11,'2023-03-10T17:00:00') 
Insert into dbo.booking values(4, 11,'2023-03-11T08:45:00') 
Insert into dbo.booking values(6, 12,'2023-03-12T10:00:00')
Insert into dbo.booking values(9, 5,'2023-03-13T14:30:00')
Insert into dbo.booking values(11, 4,'2023-03-14T16:15:00')
Insert into dbo.booking values(10, 9,'2023-12-31T00:00:00')
