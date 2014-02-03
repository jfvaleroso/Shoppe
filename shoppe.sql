USE [master]
GO
/****** Object:  Database [Shoppe]    Script Date: 02/04/2014 01:07:51 ******/
CREATE DATABASE [Shoppe] ON  PRIMARY 
( NAME = N'Shoppe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.DOGBERT\MSSQL\DATA\Shoppe.mdf' , SIZE = 649216KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Shoppe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.DOGBERT\MSSQL\DATA\Shoppe_log.ldf' , SIZE = 1219712KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Shoppe] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Shoppe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Shoppe] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Shoppe] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Shoppe] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Shoppe] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Shoppe] SET ARITHABORT OFF
GO
ALTER DATABASE [Shoppe] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Shoppe] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Shoppe] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Shoppe] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Shoppe] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Shoppe] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Shoppe] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Shoppe] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Shoppe] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Shoppe] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Shoppe] SET  DISABLE_BROKER
GO
ALTER DATABASE [Shoppe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Shoppe] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Shoppe] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Shoppe] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Shoppe] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Shoppe] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Shoppe] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Shoppe] SET  READ_WRITE
GO
ALTER DATABASE [Shoppe] SET RECOVERY FULL
GO
ALTER DATABASE [Shoppe] SET  RESTRICTED_USER
GO
ALTER DATABASE [Shoppe] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Shoppe] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Shoppe', N'ON'
GO
USE [Shoppe]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 02/04/2014 01:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[Active] [bit] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivityLogs]    Script Date: 02/04/2014 01:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ExecutedBy] [nvarchar](80) NULL,
	[Timestamp] [datetime] NULL,
 CONSTRAINT [PK_ActivityLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02/04/2014 01:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](64) NOT NULL,
	[ApplicationName] [varchar](64) NOT NULL,
	[Email] [varchar](128) NOT NULL,
	[Comment] [varchar](255) NULL,
	[Password] [varchar](64) NOT NULL,
	[PasswordQuestion] [varchar](255) NULL,
	[PasswordAnswer] [varchar](255) NULL,
	[IsApproved] [bit] NULL,
	[LastActivityDate] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[LastPasswordChangedDate] [datetime] NULL,
	[CreationDate] [datetime] NULL,
	[IsOnLine] [bit] NULL,
	[IsLockedOut] [bit] NULL,
	[LastLockedOutDate] [datetime] NULL,
	[FailedPasswordAttemptCount] [int] NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NULL,
	[FailedPasswordAnswerAttemptCount] [int] NULL,
	[FailedPasswordAnswerAttemptWindowStart] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Store]    Script Date: 02/04/2014 01:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Address] [nvarchar](200) NULL,
	[TelephoneNo] [nvarchar](50) NULL,
	[PermitNo] [nvarchar](50) NULL,
	[TINNo] [nvarchar](50) NULL,
	[Active] [bit] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 02/04/2014 01:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Active] [bit] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityCode]    Script Date: 02/04/2014 01:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityCode](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PassCode] [nvarchar](100) NULL,
	[UsedBy] [nvarchar](80) NULL,
	[DateUsed] [datetime] NULL,
	[DateCreated] [datetime] NULL,
	[IsUsed] [bit] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Password] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 02/04/2014 01:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](100) NOT NULL,
	[ApplicationName] [varchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 02/04/2014 01:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[ErrorId] [uniqueidentifier] NOT NULL,
	[Application] [nvarchar](60) NOT NULL,
	[Host] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Source] [nvarchar](60) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[User] [nvarchar](50) NOT NULL,
	[StatusCode] [int] NOT NULL,
	[TimeUtc] [datetime] NOT NULL,
	[Sequence] [int] IDENTITY(1,1) NOT NULL,
	[AllXml] [ntext] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ELMAH_Error]    Script Date: 02/04/2014 01:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ELMAH_Error](
	[ErrorId] [uniqueidentifier] NOT NULL,
	[Application] [nvarchar](60) NOT NULL,
	[Host] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Source] [nvarchar](60) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[User] [nvarchar](50) NOT NULL,
	[StatusCode] [int] NOT NULL,
	[TimeUtc] [datetime] NOT NULL,
	[Sequence] [int] IDENTITY(1,1) NOT NULL,
	[AllXml] [ntext] NOT NULL,
 CONSTRAINT [PK_ELMAH_Error] PRIMARY KEY NONCLUSTERED 
(
	[ErrorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ELMAH_Error_App_Time_Seq] ON [dbo].[ELMAH_Error] 
(
	[Application] ASC,
	[TimeUtc] DESC,
	[Sequence] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 02/04/2014 01:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[TelephoneNo] [nvarchar](20) NULL,
	[CellphoneNo] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[BirthDate] [date] NULL,
	[Gender] [nvarchar](10) NULL,
	[OfficeAddress] [nvarchar](200) NULL,
	[ResidentialAddress] [nvarchar](200) NULL,
	[PostalCode] [nchar](20) NULL,
	[City] [nvarchar](100) NULL,
	[Province] [nvarchar](100) NULL,
	[TypeOfID] [nvarchar](100) NULL,
	[IDNo] [nvarchar](50) NULL,
	[Active] [bit] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CashOnHand]    Script Date: 02/04/2014 01:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashOnHand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Store_Id] [int] NULL,
	[Cash] [decimal](18, 0) NULL,
	[Note] [nvarchar](200) NULL,
	[ReceivedBy] [nvarchar](80) NULL,
	[Source] [nvarchar](100) NULL,
	[DateReceived] [datetime] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_CashOnHand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 02/04/2014 01:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TransactionCode] [nvarchar](50) NULL,
	[Amount] [decimal](18, 0) NULL,
	[DateIssued] [datetime] NULL,
	[Cashier] [nvarchar](100) NULL,
	[Appraiser] [nvarchar](100) NULL,
	[Status_Id] [int] NULL,
	[Customer_Id] [bigint] NULL,
	[Store_Id] [int] NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_LogError]    Script Date: 02/04/2014 01:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELMAH_LogError]
(
    @ErrorId UNIQUEIDENTIFIER,
    @Application NVARCHAR(60),
    @Host NVARCHAR(30),
    @Type NVARCHAR(100),
    @Source NVARCHAR(60),
    @Message NVARCHAR(500),
    @User NVARCHAR(50),
    @AllXml NTEXT,
    @StatusCode INT,
    @TimeUtc DATETIME
)
AS

    SET NOCOUNT ON

    INSERT
    INTO
        [ELMAH_Error]
        (
            [ErrorId],
            [Application],
            [Host],
            [Type],
            [Source],
            [Message],
            [User],
            [AllXml],
            [StatusCode],
            [TimeUtc]
        )
    VALUES
        (
            @ErrorId,
            @Application,
            @Host,
            @Type,
            @Source,
            @Message,
            @User,
            @AllXml,
            @StatusCode,
            @TimeUtc
        )
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorXml]    Script Date: 02/04/2014 01:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELMAH_GetErrorXml]
(
    @Application NVARCHAR(60),
    @ErrorId UNIQUEIDENTIFIER
)
AS

    SET NOCOUNT ON

    SELECT 
        [AllXml]
    FROM 
        [ELMAH_Error]
    WHERE
        [ErrorId] = @ErrorId
    AND
        [Application] = @Application
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorsXml]    Script Date: 02/04/2014 01:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELMAH_GetErrorsXml]
(
    @Application NVARCHAR(60),
    @PageIndex INT = 0,
    @PageSize INT = 15,
    @TotalCount INT OUTPUT
)
AS 

    SET NOCOUNT ON

    DECLARE @FirstTimeUTC DATETIME
    DECLARE @FirstSequence INT
    DECLARE @StartRow INT
    DECLARE @StartRowIndex INT

    SELECT 
        @TotalCount = COUNT(1) 
    FROM 
        [ELMAH_Error]
    WHERE 
        [Application] = @Application

    -- Get the ID of the first error for the requested page

    SET @StartRowIndex = @PageIndex * @PageSize + 1

    IF @StartRowIndex <= @TotalCount
    BEGIN

        SET ROWCOUNT @StartRowIndex

        SELECT  
            @FirstTimeUTC = [TimeUtc],
            @FirstSequence = [Sequence]
        FROM 
            [ELMAH_Error]
        WHERE   
            [Application] = @Application
        ORDER BY 
            [TimeUtc] DESC, 
            [Sequence] DESC

    END
    ELSE
    BEGIN

        SET @PageSize = 0

    END

    -- Now set the row count to the requested page size and get
    -- all records below it for the pertaining application.

    SET ROWCOUNT @PageSize

    SELECT 
        errorId     = [ErrorId], 
        application = [Application],
        host        = [Host], 
        type        = [Type],
        source      = [Source],
        message     = [Message],
        [user]      = [User],
        statusCode  = [StatusCode], 
        time        = CONVERT(VARCHAR(50), [TimeUtc], 126) + 'Z'
    FROM 
        [ELMAH_Error] error
    WHERE
        [Application] = @Application
    AND
        [TimeUtc] <= @FirstTimeUTC
    AND 
        [Sequence] <= @FirstSequence
    ORDER BY
        [TimeUtc] DESC, 
        [Sequence] DESC
    FOR
        XML AUTO
GO
/****** Object:  Table [dbo].[Product]    Script Date: 02/04/2014 01:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductType_Id] [bigint] NULL,
	[Code] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[Cost] [decimal](18, 2) NULL,
	[Active] [bit] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersInStore]    Script Date: 02/04/2014 01:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInStore](
	[Users_Id] [int] NOT NULL,
	[Store_Id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersInRoles]    Script Date: 02/04/2014 01:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInRoles](
	[Users_Id] [int] NOT NULL,
	[Roles_Id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 02/04/2014 01:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Profiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Users_Id] [int] NOT NULL,
	[ApplicationName] [varchar](64) NULL,
	[IsAnonymous] [bit] NULL,
	[LastActivityDate] [datetime] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[Subscription] [varchar](50) NULL,
	[Language] [varchar](50) NULL,
	[FirstName] [varchar](80) NULL,
	[MiddleName] [varchar](80) NULL,
	[LastName] [varchar](80) NULL,
	[Gender] [char](1) NULL,
	[BirthDate] [datetime] NULL,
	[Position] [varchar](100) NULL,
	[Address] [varchar](200) NULL,
 CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductHistory]    Script Date: 02/04/2014 01:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductHistory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Product_Id] [bigint] NULL,
	[Cost] [decimal](18, 2) NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_ProductHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 02/04/2014 01:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Grams] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[Description] [nvarchar](200) NULL,
	[Cost] [decimal](18, 2) NULL,
	[Bonus] [float] NULL,
	[Total] [decimal](18, 2) NULL,
	[Rate] [nvarchar](200) NULL,
	[Status] [int] NULL,
	[Cashier] [nvarchar](80) NULL,
	[Appraiser] [nvarchar](80) NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
	[Invoice_Id] [bigint] NULL,
	[Customer_Id] [bigint] NULL,
	[Product_Id] [bigint] NULL,
	[SecurityCode_Id] [bigint] NULL,
	[Store_Id] [int] NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Note]    Script Date: 02/04/2014 01:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Note](
	[Id] [bigint] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
	[Invoice_Id] [bigint] NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_ELMAH_Error_ErrorId]    Script Date: 02/04/2014 01:07:52 ******/
ALTER TABLE [dbo].[ELMAH_Error] ADD  CONSTRAINT [DF_ELMAH_Error_ErrorId]  DEFAULT (newid()) FOR [ErrorId]
GO
/****** Object:  ForeignKey [FK_CashOnHand_Store]    Script Date: 02/04/2014 01:07:52 ******/
ALTER TABLE [dbo].[CashOnHand]  WITH CHECK ADD  CONSTRAINT [FK_CashOnHand_Store] FOREIGN KEY([Store_Id])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[CashOnHand] CHECK CONSTRAINT [FK_CashOnHand_Store]
GO
/****** Object:  ForeignKey [FK_Invoice_Customer]    Script Date: 02/04/2014 01:07:52 ******/
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Customer] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Customer]
GO
/****** Object:  ForeignKey [FK_Invoice_Status]    Script Date: 02/04/2014 01:07:52 ******/
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Status] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Status]
GO
/****** Object:  ForeignKey [FK_Invoice_Store]    Script Date: 02/04/2014 01:07:52 ******/
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Store] FOREIGN KEY([Store_Id])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Store]
GO
/****** Object:  ForeignKey [FK_Product_ProductType]    Script Date: 02/04/2014 01:07:53 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([ProductType_Id])
REFERENCES [dbo].[ProductType] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
/****** Object:  ForeignKey [FK_UsersInStore_Store]    Script Date: 02/04/2014 01:07:53 ******/
ALTER TABLE [dbo].[UsersInStore]  WITH CHECK ADD  CONSTRAINT [FK_UsersInStore_Store] FOREIGN KEY([Store_Id])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[UsersInStore] CHECK CONSTRAINT [FK_UsersInStore_Store]
GO
/****** Object:  ForeignKey [FK_UsersInStore_Users]    Script Date: 02/04/2014 01:07:53 ******/
ALTER TABLE [dbo].[UsersInStore]  WITH CHECK ADD  CONSTRAINT [FK_UsersInStore_Users] FOREIGN KEY([Users_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UsersInStore] CHECK CONSTRAINT [FK_UsersInStore_Users]
GO
/****** Object:  ForeignKey [FK_UsersInRoles_Roles]    Script Date: 02/04/2014 01:07:53 ******/
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRoles_Roles] FOREIGN KEY([Roles_Id])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [FK_UsersInRoles_Roles]
GO
/****** Object:  ForeignKey [FK_UsersInRoles_Users]    Script Date: 02/04/2014 01:07:53 ******/
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRoles_Users] FOREIGN KEY([Users_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [FK_UsersInRoles_Users]
GO
/****** Object:  ForeignKey [FK_Profiles_Users]    Script Date: 02/04/2014 01:07:53 ******/
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [FK_Profiles_Users] FOREIGN KEY([Users_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [FK_Profiles_Users]
GO
/****** Object:  ForeignKey [FK_ProductHistory_ProductHistory]    Script Date: 02/04/2014 01:07:53 ******/
ALTER TABLE [dbo].[ProductHistory]  WITH CHECK ADD  CONSTRAINT [FK_ProductHistory_ProductHistory] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductHistory] CHECK CONSTRAINT [FK_ProductHistory_ProductHistory]
GO
/****** Object:  ForeignKey [FK_Purchase_Customer]    Script Date: 02/04/2014 01:07:53 ******/
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Customer] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Customer]
GO
/****** Object:  ForeignKey [FK_Purchase_Invoice]    Script Date: 02/04/2014 01:07:53 ******/
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Invoice] FOREIGN KEY([Invoice_Id])
REFERENCES [dbo].[Invoice] ([Id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Invoice]
GO
/****** Object:  ForeignKey [FK_Purchase_Product]    Script Date: 02/04/2014 01:07:53 ******/
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Product] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Product]
GO
/****** Object:  ForeignKey [FK_Purchase_SecurityCode]    Script Date: 02/04/2014 01:07:53 ******/
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_SecurityCode] FOREIGN KEY([SecurityCode_Id])
REFERENCES [dbo].[SecurityCode] ([Id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_SecurityCode]
GO
/****** Object:  ForeignKey [FK_Purchase_Store]    Script Date: 02/04/2014 01:07:53 ******/
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Store] FOREIGN KEY([Store_Id])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Store]
GO
/****** Object:  ForeignKey [FK_Note_Invoice]    Script Date: 02/04/2014 01:07:53 ******/
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Invoice] FOREIGN KEY([Invoice_Id])
REFERENCES [dbo].[Invoice] ([Id])
GO
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Invoice]
GO
