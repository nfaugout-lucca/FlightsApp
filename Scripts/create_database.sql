CREATE TABLE [dbo].[Airports](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Lat] [decimal](7, 3) NOT NULL,
	[Long] [decimal](7, 3) NOT NULL,
 CONSTRAINT [PK_Airports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Planes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Planes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Flights](
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[PlaneId] [uniqueidentifier] NOT NULL,
	[fromId] [uniqueidentifier] NOT NULL,
	[toId] [uniqueidentifier] NOT NULL,
	[departedAt] [datetime] NULL,
	[arrivedAt] [datetime] NULL,
 CONSTRAINT [PK_Flights] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Flights]  WITH CHECK ADD FOREIGN KEY([fromId])
REFERENCES [dbo].[Airports] ([Id])
GO

ALTER TABLE [dbo].[Flights]  WITH CHECK ADD FOREIGN KEY([PlaneId])
REFERENCES [dbo].[Planes] ([Id])
GO

ALTER TABLE [dbo].[Flights]  WITH CHECK ADD FOREIGN KEY([toId])
REFERENCES [dbo].[Airports] ([Id])

GO


CREATE TABLE [dbo].[PlanePositions](
	[Id] [uniqueidentifier] NOT NULL,
	[PlaneId] [uniqueidentifier] NOT NULL,
	[Lat] [decimal](7, 3) NOT NULL,
	[Long] [decimal](7, 3) NOT NULL,
	[RecordedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_PlanePositions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





