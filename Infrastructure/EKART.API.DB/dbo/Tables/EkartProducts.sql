CREATE TABLE [dbo].[EkartProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Description] [varchar](max) NULL,
	[SKU] [varchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[InventoryId] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[DiscountId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
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
ALTER TABLE [dbo].[EkartProducts]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[EkartProductCategory] ([Id])
GO
ALTER TABLE [dbo].[EkartProducts]  WITH CHECK ADD FOREIGN KEY([DiscountId])
REFERENCES [dbo].[EkartProductDiscount] ([Id])
GO
ALTER TABLE [dbo].[EkartProducts]  WITH CHECK ADD FOREIGN KEY([InventoryId])
REFERENCES [dbo].[EkartProductInventory] ([Id])