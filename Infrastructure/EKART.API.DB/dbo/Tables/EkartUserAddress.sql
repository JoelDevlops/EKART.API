CREATE TABLE [dbo].[EkartUserAddress](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AddressLine1] [varchar](max) NOT NULL,
	[AddressLine2] [varchar](max) NOT NULL,
	[City] [varchar](150) NOT NULL,
	[PostalCode] [int] NOT NULL,
	[Country] [varchar](150) NOT NULL,
	[PhoneNumber] [int] NOT NULL,
	[CreatedBy] [varchar](100) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](100) NULL,
	[UpdatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[EkartUserAddress]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[EkartUserDetail] ([Id])