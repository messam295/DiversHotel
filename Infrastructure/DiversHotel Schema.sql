
CREATE TABLE RoomType(
	RoomTypeId		INT				IDENTITY(1,1)	NOT NULL,
	RoomTypeName	NVARCHAR(255)					NOT NULL,

	CONSTRAINT PK_RoomType PRIMARY KEY (RoomTypeId)
)

CREATE TABLE Room(
	RoomId			INT				IDENTITY(1,1)	NOT NULL,
	RoomNumber		NVARCHAR(255)					NOT NULL,
	RoomTypeId		INT								NOT NULL

	CONSTRAINT PK_Room PRIMARY KEY (RoomId),
    CONSTRAINT FK_Room_RoomType FOREIGN KEY (RoomTypeId) REFERENCES RoomType(RoomTypeId)
)

CREATE TABLE RoomTypePrice(
	RoomTypePriceId		INT			IDENTITY(1,1)	NOT NULL,
	RoomTypeId			INT							NOT NULL,
	PricePerNight		MONEY						NOT NULL,
	FromDateUtc			DATE						NOT NULL,
	ToDateUtc			DATE						NOT NULL,

	CONSTRAINT PK_RoomTypePrice PRIMARY KEY (RoomTypePriceId),
    CONSTRAINT FK_RoomTypePrice_RoomType FOREIGN KEY (RoomTypeId) REFERENCES RoomType(RoomTypeId)
)

CREATE TABLE MealPlan(
	MealPlanId			INT			IDENTITY(1,1)	NOT NULL,
	Name				NVARCHAR(255)				NOT NULL,
	Description			NVARCHAR(1000)				NULL,
	
	CONSTRAINT PK_MealPlan PRIMARY KEY (MealPlanId)
)

CREATE TABLE MealPlanPrice(
	MealPlanPriceId		INT			IDENTITY(1,1)	NOT NULL,
	MealPlanId			INT							NOT NULL,
	PricePerPerson		MONEY						NOT NULL,
	FromDateUtc			DATE						NOT NULL,
	ToDateUtc			DATE						NOT NULL,

	CONSTRAINT PK_MealPlanPrice PRIMARY KEY (MealPlanPriceId),
    CONSTRAINT FK_MealPlanPrice_MealPlan FOREIGN KEY (MealPlanId) REFERENCES MealPlan(MealPlanId)
)

CREATE TABLE Reservation(
	ReservationId		INT			IDENTITY(1,1)	NOT NULL,
	Name				NVARCHAR(255)				NOT NULL,
	Email				NVARCHAR(255)				NOT NULL,
	Country				NVARCHAR(255)				NOT NULL,
	NumberOfAdults		INT							NOT NULL,
	NumberOfChildren	INT							NOT NULL,
	CheckInDateUtc		DATE						NOT NULL,
	CheckOutDateUtc		DATE						NOT NULL,
	RoomId				INT							NOT NULL,
	MealPlanId			INT							NOT NULL,
	TotalAmount			MONEY						NOT NULL,

	CONSTRAINT PK_Reservation PRIMARY KEY (ReservationId),
    CONSTRAINT FK_Reservation_Room FOREIGN KEY (RoomId) REFERENCES Room(RoomId),
    CONSTRAINT FK_Reservation_MealPlan FOREIGN KEY (MealPlanId) REFERENCES MealPlan(MealPlanId)
)
