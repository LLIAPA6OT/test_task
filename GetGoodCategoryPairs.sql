select g.name, c.name from goods g 
left join goodscategoriesrel gcr on g.id = gcr.goodid
left join categories c on gcr.categoryid = c.id

/*Схема для которой писался запрос
CREATE TABLE [dbo].[categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[goods](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NOT NULL,
 CONSTRAINT [PK_goods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[goodscategoriesrel](
	[goodid] [int] NOT NULL,
	[categoryid] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[goodscategoriesrel]  WITH CHECK ADD  CONSTRAINT [FK_goodscategoriesrel_categories] FOREIGN KEY([categoryid])
REFERENCES [dbo].[categories] ([id])
GO
ALTER TABLE [dbo].[goodscategoriesrel] CHECK CONSTRAINT [FK_goodscategoriesrel_categories]
GO
ALTER TABLE [dbo].[goodscategoriesrel]  WITH CHECK ADD  CONSTRAINT [FK_goodscategoriesrel_goods] FOREIGN KEY([goodid])
REFERENCES [dbo].[goods] ([id])
GO
ALTER TABLE [dbo].[goodscategoriesrel] CHECK CONSTRAINT [FK_goodscategoriesrel_goods]
GO
*/

