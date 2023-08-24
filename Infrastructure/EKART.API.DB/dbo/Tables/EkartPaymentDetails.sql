CREATE TABLE [dbo].[EkartPaymentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[Provider] [varchar](200) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedBy] [varchar](100) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [varchar](100) NULL,
	[UpdatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EkartPaymentDetails] ADD  DEFAULT ((1)) FOR [Provider]