CREATE TABLE [dbo].[EkartOrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
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
ALTER TABLE [dbo].[EkartOrderItem]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[EkartOrderDetails] ([Id])
GO
ALTER TABLE [dbo].[EkartOrderItem]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[EkartProducts] ([Id])
GO
ALTER TABLE [dbo].[EkartOrderItem] ADD  DEFAULT ((1)) FOR [Quantity]