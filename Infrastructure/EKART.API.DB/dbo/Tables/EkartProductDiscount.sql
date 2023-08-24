CREATE TABLE [dbo].[EkartProductDiscount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DiscountPercentage] [decimal](18, 0) NOT NULL,
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
ALTER TABLE [dbo].[EkartProductDiscount]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[EkartProducts] ([Id])
GO
ALTER TABLE [dbo].[EkartProductDiscount] ADD  DEFAULT ((0)) FOR [DiscountPercentage]