USE [master]
GO
/****** Object:  Database [Shoppe2]    Script Date: 04/20/2014 10:22:01 ******/
CREATE DATABASE [Shoppe2] ON  PRIMARY 
( NAME = N'Shoppe2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.DOGBERT\MSSQL\DATA\Shoppe2.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Shoppe2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.DOGBERT\MSSQL\DATA\Shoppe2_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Shoppe2] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Shoppe2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Shoppe2] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Shoppe2] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Shoppe2] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Shoppe2] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Shoppe2] SET ARITHABORT OFF
GO
ALTER DATABASE [Shoppe2] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Shoppe2] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Shoppe2] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Shoppe2] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Shoppe2] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Shoppe2] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Shoppe2] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Shoppe2] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Shoppe2] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Shoppe2] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Shoppe2] SET  DISABLE_BROKER
GO
ALTER DATABASE [Shoppe2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Shoppe2] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Shoppe2] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Shoppe2] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Shoppe2] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Shoppe2] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Shoppe2] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Shoppe2] SET  READ_WRITE
GO
ALTER DATABASE [Shoppe2] SET RECOVERY FULL
GO
ALTER DATABASE [Shoppe2] SET  MULTI_USER
GO
ALTER DATABASE [Shoppe2] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Shoppe2] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Shoppe2', N'ON'
GO
USE [Shoppe2]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/20/2014 10:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
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
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Store]    Script Date: 04/20/2014 10:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [uniqueidentifier] NOT NULL,
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
 CONSTRAINT [PK_Store_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Store] ([Id], [Code], [Name], [Address], [TelephoneNo], [PermitNo], [TINNo], [Active], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (N'd8abd96e-c652-4f2f-8c48-a3050187469f', N'GTW', N'Gateway', N'Quezon City, Manila', N'09297700762', N'000111', N'01111', 1, N'jfvaleroso', CAST(0x0000A30501874604 AS DateTime), N'jfvaleroso', CAST(0x0000A30501891BF0 AS DateTime))
INSERT [dbo].[Store] ([Id], [Code], [Name], [Address], [TelephoneNo], [PermitNo], [TINNo], [Active], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (N'c3a29573-01e0-45c5-bd61-a30501899569', N'GRB', N'Greenbelt', N'Makati City', N'09297700762', NULL, N'111111', 1, N'jfvaleroso', CAST(0x0000A305018994A4 AS DateTime), NULL, NULL)
/****** Object:  Table [dbo].[Status]    Script Date: 04/20/2014 10:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Active] [bit] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_Status_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityCode]    Script Date: 04/20/2014 10:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityCode](
	[Id] [uniqueidentifier] NOT NULL,
	[PassCode] [nvarchar](100) NULL,
	[UsedBy] [nvarchar](80) NULL,
	[DateUsed] [datetime] NULL,
	[DateCreated] [datetime] NULL,
	[IsUsed] [bit] NULL,
	[Status] [int] NULL,
	[Bonus] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SecurityCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 04/20/2014 10:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [uniqueidentifier] NOT NULL,
	[RoleName] [varchar](100) NOT NULL,
	[ApplicationName] [varchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Roles_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 04/20/2014 10:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[Id] [uniqueidentifier] NOT NULL,
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
INSERT [dbo].[ProductType] ([Id], [Code], [Name], [Description], [Active], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (N'11b19ff1-90ec-498c-8f52-a3060180cb35', N'100', N'Gold', N'Gold', 1, N'jfvaleroso', CAST(0x0000A3060180CAA4 AS DateTime), NULL, NULL)
/****** Object:  Table [dbo].[ActivityLogs]    Script Date: 04/20/2014 10:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityLogs](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ExecutedBy] [nvarchar](80) NULL,
	[Timestamp] [datetime] NULL,
 CONSTRAINT [PK_ActivityLogs_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ELMAH_Error]    Script Date: 04/20/2014 10:22:03 ******/
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
SET IDENTITY_INSERT [dbo].[ELMAH_Error] ON
INSERT [dbo].[ELMAH_Error] ([ErrorId], [Application], [Host], [Type], [Source], [Message], [User], [StatusCode], [TimeUtc], [Sequence], [AllXml]) VALUES (N'cdbf32d7-23e0-4a5b-866c-90a3c2a04467', N'/LM/W3SVC/3/ROOT', N'JFVALEROSO-PC', N'System.NullReferenceException', N'Exchange.Web', N'Object reference not set to an instance of an object.', N'jfvaleroso', 0, CAST(0x0000A305010582ED AS DateTime), 1, N'<error
  application="/LM/W3SVC/3/ROOT"
  host="JFVALEROSO-PC"
  type="System.NullReferenceException"
  message="Object reference not set to an instance of an object."
  source="Exchange.Web"
  detail="System.NullReferenceException: Object reference not set to an instance of an object.&#xD;&#xA;   at Exchange.Web.Helper.Common.GetCurrentUserStoreAccess() in c:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Helper\Common.cs:line 45&#xD;&#xA;   at Exchange.Web.Controllers.BuyController.Index() in c:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Controllers\BuyController.cs:line 50&#xD;&#xA;   at lambda_method(Closure , ControllerBase , Object[] )&#xD;&#xA;   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)&#xD;&#xA;   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)&#xD;&#xA;   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.InvokeSynchronousActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass42.&lt;BeginInvokeSynchronousActionMethod&gt;b__41()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass8`1.&lt;BeginSynchronous&gt;b__7(IAsyncResult _)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)&#xD;&#xA;   at Castle.Proxies.AsyncControllerActionInvokerProxy.EndInvokeActionMethod_callback(IAsyncResult asyncResult)&#xD;&#xA;   at Castle.Proxies.Invocations.AsyncControllerActionInvoker_EndInvokeActionMethod.InvokeMethodOnTarget()&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Glimpse.Core.Extensibility.CastleInvocationToAlternateMethodContextAdapter.Proceed()&#xD;&#xA;   at Glimpse.Mvc.AlternateType.AsyncActionInvoker.EndInvokeActionMethod.NewImplementation(IAlternateMethodContext context)&#xD;&#xA;   at Glimpse.Core.Extensibility.AlternateTypeToCastleInterceptorAdapter.Intercept(IInvocation invocation)&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Castle.Proxies.AsyncControllerActionInvokerProxy.EndInvokeActionMethod(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass37.&lt;&gt;c__DisplayClass39.&lt;BeginInvokeActionMethodWithFilters&gt;b__33()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass4f.&lt;InvokeActionMethodFilterAsynchronously&gt;b__49()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass37.&lt;BeginInvokeActionMethodWithFilters&gt;b__36(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass25.&lt;&gt;c__DisplayClass2a.&lt;BeginInvokeAction&gt;b__20()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass25.&lt;BeginInvokeAction&gt;b__22(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.&lt;&gt;c__DisplayClass1d.&lt;BeginExecuteCore&gt;b__18(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.&lt;&gt;c__DisplayClass8.&lt;BeginProcessRequest&gt;b__3(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean&amp; completedSynchronously)"
  user="jfvaleroso"
  time="2014-04-06T15:52:08.0433251Z">
  <serverVariables>
    <item
      name="ALL_HTTP">
      <value
        string="HTTP_CONNECTION:keep-alive&#xD;&#xA;HTTP_ACCEPT:text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8&#xD;&#xA;HTTP_ACCEPT_ENCODING:gzip,deflate,sdch&#xD;&#xA;HTTP_ACCEPT_LANGUAGE:en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;HTTP_COOKIE:glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=XY5Pe7KlX8SXwnlrh4DqIvP8-syS0oKjTNbNChGQapyeLtSIYdyr1nY_G6_hKTXnt0Y3LKq3dsO1oXhXQ0kzxs02zBO7t1akhjRObnoS_NHkq0-luZhzxE5pGc1HtHzjCfL-J293hl2RjN3gl_izYPgFOj8qoUTVzXF5cHu7GXr9fihKQQ8IlEzU2cw1jSWXYjlx3Z3ImAdawIfLD-dU2XpEnvGV1EJaQiKbVZUC0dlLBM2n3mgIWP1kairqvPL3_5GsiSWmc4er4kp3EFDVueBZzjFwCGZYtibHHy5zkzpzME3Yent6EAOeOERntnng5g3HvMMmALfAJAWLXIj2Un9uH4JFiZpeyw-840VwlFnkKVxmXdyZdgpgxXg7i6scH_wmzD-hZCDtMJVXFQZUiwtEg8KUHfCeFyjFsXlCF7sQ1L5kZbfWtLWYeCbTggrLCJ-sP7ea1do2z1iRHQDsirqpEXGTqgKwfAYoFxFpVER9JRGzVUwKawWgfqSrAFqQ2cqqVDGzpDM_eKpjtJyOjAHP7MU1&#xD;&#xA;HTTP_HOST:localhost:26079&#xD;&#xA;HTTP_REFERER:http://localhost:26079/Admin/Store/Manage/d8abd96e-c652-4f2f-8c48-a3050187469f&#xD;&#xA;HTTP_USER_AGENT:Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;" />
    </item>
    <item
      name="ALL_RAW">
      <value
        string="Connection: keep-alive&#xD;&#xA;Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8&#xD;&#xA;Accept-Encoding: gzip,deflate,sdch&#xD;&#xA;Accept-Language: en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;Cookie: glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=XY5Pe7KlX8SXwnlrh4DqIvP8-syS0oKjTNbNChGQapyeLtSIYdyr1nY_G6_hKTXnt0Y3LKq3dsO1oXhXQ0kzxs02zBO7t1akhjRObnoS_NHkq0-luZhzxE5pGc1HtHzjCfL-J293hl2RjN3gl_izYPgFOj8qoUTVzXF5cHu7GXr9fihKQQ8IlEzU2cw1jSWXYjlx3Z3ImAdawIfLD-dU2XpEnvGV1EJaQiKbVZUC0dlLBM2n3mgIWP1kairqvPL3_5GsiSWmc4er4kp3EFDVueBZzjFwCGZYtibHHy5zkzpzME3Yent6EAOeOERntnng5g3HvMMmALfAJAWLXIj2Un9uH4JFiZpeyw-840VwlFnkKVxmXdyZdgpgxXg7i6scH_wmzD-hZCDtMJVXFQZUiwtEg8KUHfCeFyjFsXlCF7sQ1L5kZbfWtLWYeCbTggrLCJ-sP7ea1do2z1iRHQDsirqpEXGTqgKwfAYoFxFpVER9JRGzVUwKawWgfqSrAFqQ2cqqVDGzpDM_eKpjtJyOjAHP7MU1&#xD;&#xA;Host: localhost:26079&#xD;&#xA;Referer: http://localhost:26079/Admin/Store/Manage/d8abd96e-c652-4f2f-8c48-a3050187469f&#xD;&#xA;User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;" />
    </item>
    <item
      name="APPL_MD_PATH">
      <value
        string="/LM/W3SVC/3/ROOT" />
    </item>
    <item
      name="APPL_PHYSICAL_PATH">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\" />
    </item>
    <item
      name="AUTH_TYPE">
      <value
        string="Forms" />
    </item>
    <item
      name="AUTH_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="AUTH_PASSWORD">
      <value
        string="*****" />
    </item>
    <item
      name="LOGON_USER">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="CERT_COOKIE">
      <value
        string="" />
    </item>
    <item
      name="CERT_FLAGS">
      <value
        string="" />
    </item>
    <item
      name="CERT_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERIALNUMBER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CERT_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CONTENT_LENGTH">
      <value
        string="0" />
    </item>
    <item
      name="CONTENT_TYPE">
      <value
        string="" />
    </item>
    <item
      name="GATEWAY_INTERFACE">
      <value
        string="CGI/1.1" />
    </item>
    <item
      name="HTTPS">
      <value
        string="off" />
    </item>
    <item
      name="HTTPS_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="INSTANCE_ID">
      <value
        string="3" />
    </item>
    <item
      name="INSTANCE_META_PATH">
      <value
        string="/LM/W3SVC/3" />
    </item>
    <item
      name="LOCAL_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="PATH_INFO">
      <value
        string="/Buy" />
    </item>
    <item
      name="PATH_TRANSLATED">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Buy" />
    </item>
    <item
      name="QUERY_STRING">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_HOST">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_PORT">
      <value
        string="43036" />
    </item>
    <item
      name="REQUEST_METHOD">
      <value
        string="GET" />
    </item>
    <item
      name="SCRIPT_NAME">
      <value
        string="/Buy" />
    </item>
    <item
      name="SERVER_NAME">
      <value
        string="localhost" />
    </item>
    <item
      name="SERVER_PORT">
      <value
        string="26079" />
    </item>
    <item
      name="SERVER_PORT_SECURE">
      <value
        string="0" />
    </item>
    <item
      name="SERVER_PROTOCOL">
      <value
        string="HTTP/1.1" />
    </item>
    <item
      name="SERVER_SOFTWARE">
      <value
        string="Microsoft-IIS/8.0" />
    </item>
    <item
      name="URL">
      <value
        string="/Buy" />
    </item>
    <item
      name="HTTP_CONNECTION">
      <value
        string="keep-alive" />
    </item>
    <item
      name="HTTP_ACCEPT">
      <value
        string="text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8" />
    </item>
    <item
      name="HTTP_ACCEPT_ENCODING">
      <value
        string="gzip,deflate,sdch" />
    </item>
    <item
      name="HTTP_ACCEPT_LANGUAGE">
      <value
        string="en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2" />
    </item>
    <item
      name="HTTP_COOKIE">
      <value
        string="glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=XY5Pe7KlX8SXwnlrh4DqIvP8-syS0oKjTNbNChGQapyeLtSIYdyr1nY_G6_hKTXnt0Y3LKq3dsO1oXhXQ0kzxs02zBO7t1akhjRObnoS_NHkq0-luZhzxE5pGc1HtHzjCfL-J293hl2RjN3gl_izYPgFOj8qoUTVzXF5cHu7GXr9fihKQQ8IlEzU2cw1jSWXYjlx3Z3ImAdawIfLD-dU2XpEnvGV1EJaQiKbVZUC0dlLBM2n3mgIWP1kairqvPL3_5GsiSWmc4er4kp3EFDVueBZzjFwCGZYtibHHy5zkzpzME3Yent6EAOeOERntnng5g3HvMMmALfAJAWLXIj2Un9uH4JFiZpeyw-840VwlFnkKVxmXdyZdgpgxXg7i6scH_wmzD-hZCDtMJVXFQZUiwtEg8KUHfCeFyjFsXlCF7sQ1L5kZbfWtLWYeCbTggrLCJ-sP7ea1do2z1iRHQDsirqpEXGTqgKwfAYoFxFpVER9JRGzVUwKawWgfqSrAFqQ2cqqVDGzpDM_eKpjtJyOjAHP7MU1" />
    </item>
    <item
      name="HTTP_HOST">
      <value
        string="localhost:26079" />
    </item>
    <item
      name="HTTP_REFERER">
      <value
        string="http://localhost:26079/Admin/Store/Manage/d8abd96e-c652-4f2f-8c48-a3050187469f" />
    </item>
    <item
      name="HTTP_USER_AGENT">
      <value
        string="Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36" />
    </item>
  </serverVariables>
  <cookies>
    <item
      name="glimpsePolicy">
      <value
        string="On" />
    </item>
    <item
      name="glimpseOptions">
      <value
        string="%7B%22glimpsePolicy%22%3Anull%7D" />
    </item>
    <item
      name="__RequestVerificationToken">
      <value
        string="4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2" />
    </item>
    <item
      name="glimpseId">
      <value
        string="Chrome 33.0" />
    </item>
    <item
      name=".ASPXAUTH">
      <value
        string="2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA" />
    </item>
    <item
      name="ASP.NET_SessionId">
      <value
        string="ckpwa1rl1tiwbvzghywr4fd0" />
    </item>
    <item
      name=".ASPROLES">
      <value
        string="XY5Pe7KlX8SXwnlrh4DqIvP8-syS0oKjTNbNChGQapyeLtSIYdyr1nY_G6_hKTXnt0Y3LKq3dsO1oXhXQ0kzxs02zBO7t1akhjRObnoS_NHkq0-luZhzxE5pGc1HtHzjCfL-J293hl2RjN3gl_izYPgFOj8qoUTVzXF5cHu7GXr9fihKQQ8IlEzU2cw1jSWXYjlx3Z3ImAdawIfLD-dU2XpEnvGV1EJaQiKbVZUC0dlLBM2n3mgIWP1kairqvPL3_5GsiSWmc4er4kp3EFDVueBZzjFwCGZYtibHHy5zkzpzME3Yent6EAOeOERntnng5g3HvMMmALfAJAWLXIj2Un9uH4JFiZpeyw-840VwlFnkKVxmXdyZdgpgxXg7i6scH_wmzD-hZCDtMJVXFQZUiwtEg8KUHfCeFyjFsXlCF7sQ1L5kZbfWtLWYeCbTggrLCJ-sP7ea1do2z1iRHQDsirqpEXGTqgKwfAYoFxFpVER9JRGzVUwKawWgfqSrAFqQ2cqqVDGzpDM_eKpjtJyOjAHP7MU1" />
    </item>
  </cookies>
</error>')
INSERT [dbo].[ELMAH_Error] ([ErrorId], [Application], [Host], [Type], [Source], [Message], [User], [StatusCode], [TimeUtc], [Sequence], [AllXml]) VALUES (N'9b425a6c-eb93-4cc7-bde4-d53a1bd8f822', N'/LM/W3SVC/3/ROOT', N'JFVALEROSO-PC', N'System.Web.HttpException', N'System.Web.Mvc', N'A public action method ''Register'' was not found on controller ''Exchange.Web.Controllers.CustomerController''.', N'jfvaleroso', 404, CAST(0x0000A3050107AA8B AS DateTime), 2, N'<error
  application="/LM/W3SVC/3/ROOT"
  host="JFVALEROSO-PC"
  type="System.Web.HttpException"
  message="A public action method ''Register'' was not found on controller ''Exchange.Web.Controllers.CustomerController''."
  source="System.Web.Mvc"
  detail="System.Web.HttpException (0x80004005): A public action method ''Register'' was not found on controller ''Exchange.Web.Controllers.CustomerController''.&#xD;&#xA;   at System.Web.Mvc.Controller.HandleUnknownAction(String actionName)&#xD;&#xA;   at System.Web.Mvc.Controller.&lt;&gt;c__DisplayClass1d.&lt;BeginExecuteCore&gt;b__18(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.&lt;&gt;c__DisplayClass8.&lt;BeginProcessRequest&gt;b__3(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean&amp; completedSynchronously)"
  user="jfvaleroso"
  time="2014-04-06T15:59:58.7578265Z"
  statusCode="404">
  <serverVariables>
    <item
      name="ALL_HTTP">
      <value
        string="HTTP_CONNECTION:keep-alive&#xD;&#xA;HTTP_CONTENT_LENGTH:184&#xD;&#xA;HTTP_CONTENT_TYPE:application/x-www-form-urlencoded; charset=UTF-8&#xD;&#xA;HTTP_ACCEPT:*/*&#xD;&#xA;HTTP_ACCEPT_ENCODING:gzip,deflate,sdch&#xD;&#xA;HTTP_ACCEPT_LANGUAGE:en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;HTTP_COOKIE:glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=OFeHDw4SBGyhtWJPd_uXP6oMPyz7u83GwvecoBAZ2i005XXb4jUYSNZNkEby3jmLDMO00Ds18nyoA-HfrqU1Tqnc1k57p4ZFecErUaaYPj9BD4B7kdBkZr1J-LBZvUgwSwYyabvXIzxaD_h0t4wDGu3YKndKoh5bliozb-fyYh2A6Hv4YJppHRU-LjbhN_GLR5SK46uajBVButYVHp_q6xgW5iLNqEZhGWt2_xd2g368VGk2ACr5v3kMtnWYbjS6csCOq5T9CDEAflLk5oPl8drZjoDKNvvw_GLafoozL_lqtF7wj46BQZ2YrafjHMdDWH1gxHv4TWgKUbxtMUVV1WJfIZGUQ8ykYyy9u2F3ChdQPagrzkFqO1PPhdEbjdvEy47LQ6CA8XXzLlCoM5SaItqO486toMom-W7BFpiVH6jIV1b50Iv0mefsYERqC-ccLGPLJ54ggMleUhJfE29YE-HSp4_pQ8mohZ1dasPu6iu31PnniZKy-mMc3sgMZ1QYWhiIwgDOMzZT6UJt7JNsJyHRESM1&#xD;&#xA;HTTP_HOST:localhost:26079&#xD;&#xA;HTTP_REFERER:http://localhost:26079/Customer/new&#xD;&#xA;HTTP_USER_AGENT:Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;HTTP_GLIMPSE_PARENT_REQUESTID:1ea45a10-55d4-4968-94c8-6955c26261b2&#xD;&#xA;HTTP_ORIGIN:http://localhost:26079&#xD;&#xA;HTTP_X_REQUESTED_WITH:XMLHttpRequest&#xD;&#xA;" />
    </item>
    <item
      name="ALL_RAW">
      <value
        string="Connection: keep-alive&#xD;&#xA;Content-Length: 184&#xD;&#xA;Content-Type: application/x-www-form-urlencoded; charset=UTF-8&#xD;&#xA;Accept: */*&#xD;&#xA;Accept-Encoding: gzip,deflate,sdch&#xD;&#xA;Accept-Language: en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;Cookie: glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=OFeHDw4SBGyhtWJPd_uXP6oMPyz7u83GwvecoBAZ2i005XXb4jUYSNZNkEby3jmLDMO00Ds18nyoA-HfrqU1Tqnc1k57p4ZFecErUaaYPj9BD4B7kdBkZr1J-LBZvUgwSwYyabvXIzxaD_h0t4wDGu3YKndKoh5bliozb-fyYh2A6Hv4YJppHRU-LjbhN_GLR5SK46uajBVButYVHp_q6xgW5iLNqEZhGWt2_xd2g368VGk2ACr5v3kMtnWYbjS6csCOq5T9CDEAflLk5oPl8drZjoDKNvvw_GLafoozL_lqtF7wj46BQZ2YrafjHMdDWH1gxHv4TWgKUbxtMUVV1WJfIZGUQ8ykYyy9u2F3ChdQPagrzkFqO1PPhdEbjdvEy47LQ6CA8XXzLlCoM5SaItqO486toMom-W7BFpiVH6jIV1b50Iv0mefsYERqC-ccLGPLJ54ggMleUhJfE29YE-HSp4_pQ8mohZ1dasPu6iu31PnniZKy-mMc3sgMZ1QYWhiIwgDOMzZT6UJt7JNsJyHRESM1&#xD;&#xA;Host: localhost:26079&#xD;&#xA;Referer: http://localhost:26079/Customer/new&#xD;&#xA;User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;Glimpse-Parent-RequestID: 1ea45a10-55d4-4968-94c8-6955c26261b2&#xD;&#xA;Origin: http://localhost:26079&#xD;&#xA;X-Requested-With: XMLHttpRequest&#xD;&#xA;" />
    </item>
    <item
      name="APPL_MD_PATH">
      <value
        string="/LM/W3SVC/3/ROOT" />
    </item>
    <item
      name="APPL_PHYSICAL_PATH">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\" />
    </item>
    <item
      name="AUTH_TYPE">
      <value
        string="Forms" />
    </item>
    <item
      name="AUTH_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="AUTH_PASSWORD">
      <value
        string="*****" />
    </item>
    <item
      name="LOGON_USER">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="CERT_COOKIE">
      <value
        string="" />
    </item>
    <item
      name="CERT_FLAGS">
      <value
        string="" />
    </item>
    <item
      name="CERT_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERIALNUMBER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CERT_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CONTENT_LENGTH">
      <value
        string="184" />
    </item>
    <item
      name="CONTENT_TYPE">
      <value
        string="application/x-www-form-urlencoded; charset=UTF-8" />
    </item>
    <item
      name="GATEWAY_INTERFACE">
      <value
        string="CGI/1.1" />
    </item>
    <item
      name="HTTPS">
      <value
        string="off" />
    </item>
    <item
      name="HTTPS_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="INSTANCE_ID">
      <value
        string="3" />
    </item>
    <item
      name="INSTANCE_META_PATH">
      <value
        string="/LM/W3SVC/3" />
    </item>
    <item
      name="LOCAL_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="PATH_INFO">
      <value
        string="/Customer/Register" />
    </item>
    <item
      name="PATH_TRANSLATED">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Customer\Register" />
    </item>
    <item
      name="QUERY_STRING">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_HOST">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_PORT">
      <value
        string="43132" />
    </item>
    <item
      name="REQUEST_METHOD">
      <value
        string="POST" />
    </item>
    <item
      name="SCRIPT_NAME">
      <value
        string="/Customer/Register" />
    </item>
    <item
      name="SERVER_NAME">
      <value
        string="localhost" />
    </item>
    <item
      name="SERVER_PORT">
      <value
        string="26079" />
    </item>
    <item
      name="SERVER_PORT_SECURE">
      <value
        string="0" />
    </item>
    <item
      name="SERVER_PROTOCOL">
      <value
        string="HTTP/1.1" />
    </item>
    <item
      name="SERVER_SOFTWARE">
      <value
        string="Microsoft-IIS/8.0" />
    </item>
    <item
      name="URL">
      <value
        string="/Customer/Register" />
    </item>
    <item
      name="HTTP_CONNECTION">
      <value
        string="keep-alive" />
    </item>
    <item
      name="HTTP_CONTENT_LENGTH">
      <value
        string="184" />
    </item>
    <item
      name="HTTP_CONTENT_TYPE">
      <value
        string="application/x-www-form-urlencoded; charset=UTF-8" />
    </item>
    <item
      name="HTTP_ACCEPT">
      <value
        string="*/*" />
    </item>
    <item
      name="HTTP_ACCEPT_ENCODING">
      <value
        string="gzip,deflate,sdch" />
    </item>
    <item
      name="HTTP_ACCEPT_LANGUAGE">
      <value
        string="en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2" />
    </item>
    <item
      name="HTTP_COOKIE">
      <value
        string="glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=OFeHDw4SBGyhtWJPd_uXP6oMPyz7u83GwvecoBAZ2i005XXb4jUYSNZNkEby3jmLDMO00Ds18nyoA-HfrqU1Tqnc1k57p4ZFecErUaaYPj9BD4B7kdBkZr1J-LBZvUgwSwYyabvXIzxaD_h0t4wDGu3YKndKoh5bliozb-fyYh2A6Hv4YJppHRU-LjbhN_GLR5SK46uajBVButYVHp_q6xgW5iLNqEZhGWt2_xd2g368VGk2ACr5v3kMtnWYbjS6csCOq5T9CDEAflLk5oPl8drZjoDKNvvw_GLafoozL_lqtF7wj46BQZ2YrafjHMdDWH1gxHv4TWgKUbxtMUVV1WJfIZGUQ8ykYyy9u2F3ChdQPagrzkFqO1PPhdEbjdvEy47LQ6CA8XXzLlCoM5SaItqO486toMom-W7BFpiVH6jIV1b50Iv0mefsYERqC-ccLGPLJ54ggMleUhJfE29YE-HSp4_pQ8mohZ1dasPu6iu31PnniZKy-mMc3sgMZ1QYWhiIwgDOMzZT6UJt7JNsJyHRESM1" />
    </item>
    <item
      name="HTTP_HOST">
      <value
        string="localhost:26079" />
    </item>
    <item
      name="HTTP_REFERER">
      <value
        string="http://localhost:26079/Customer/new" />
    </item>
    <item
      name="HTTP_USER_AGENT">
      <value
        string="Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36" />
    </item>
    <item
      name="HTTP_GLIMPSE_PARENT_REQUESTID">
      <value
        string="1ea45a10-55d4-4968-94c8-6955c26261b2" />
    </item>
    <item
      name="HTTP_ORIGIN">
      <value
        string="http://localhost:26079" />
    </item>
    <item
      name="HTTP_X_REQUESTED_WITH">
      <value
        string="XMLHttpRequest" />
    </item>
  </serverVariables>
  <form>
    <item
      name="FirstName">
      <value
        string="asdfa" />
    </item>
    <item
      name="MiddleName">
      <value
        string="asfd" />
    </item>
    <item
      name="LastName">
      <value
        string="asfd" />
    </item>
    <item
      name="Gender">
      <value
        string="F" />
    </item>
    <item
      name="BirthDate">
      <value
        string="07/01/2014" />
    </item>
    <item
      name="CellphoneNo">
      <value
        string="09297700762" />
    </item>
    <item
      name="Email">
      <value
        string="asdf" />
    </item>
    <item
      name="ResidentialAddress">
      <value
        string="asdf" />
    </item>
    <item
      name="OfficeAddress">
      <value
        string="asfd" />
    </item>
    <item
      name="TypeOfID">
      <value
        string="COMPID" />
    </item>
    <item
      name="IDNo">
      <value
        string="34234" />
    </item>
  </form>
  <cookies>
    <item
      name="glimpsePolicy">
      <value
        string="On" />
    </item>
    <item
      name="glimpseOptions">
      <value
        string="%7B%22glimpsePolicy%22%3Anull%7D" />
    </item>
    <item
      name="__RequestVerificationToken">
      <value
        string="4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2" />
    </item>
    <item
      name="glimpseId">
      <value
        string="Chrome 33.0" />
    </item>
    <item
      name=".ASPXAUTH">
      <value
        string="2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA" />
    </item>
    <item
      name="ASP.NET_SessionId">
      <value
        string="ckpwa1rl1tiwbvzghywr4fd0" />
    </item>
    <item
      name=".ASPROLES">
      <value
        string="OFeHDw4SBGyhtWJPd_uXP6oMPyz7u83GwvecoBAZ2i005XXb4jUYSNZNkEby3jmLDMO00Ds18nyoA-HfrqU1Tqnc1k57p4ZFecErUaaYPj9BD4B7kdBkZr1J-LBZvUgwSwYyabvXIzxaD_h0t4wDGu3YKndKoh5bliozb-fyYh2A6Hv4YJppHRU-LjbhN_GLR5SK46uajBVButYVHp_q6xgW5iLNqEZhGWt2_xd2g368VGk2ACr5v3kMtnWYbjS6csCOq5T9CDEAflLk5oPl8drZjoDKNvvw_GLafoozL_lqtF7wj46BQZ2YrafjHMdDWH1gxHv4TWgKUbxtMUVV1WJfIZGUQ8ykYyy9u2F3ChdQPagrzkFqO1PPhdEbjdvEy47LQ6CA8XXzLlCoM5SaItqO486toMom-W7BFpiVH6jIV1b50Iv0mefsYERqC-ccLGPLJ54ggMleUhJfE29YE-HSp4_pQ8mohZ1dasPu6iu31PnniZKy-mMc3sgMZ1QYWhiIwgDOMzZT6UJt7JNsJyHRESM1" />
    </item>
  </cookies>
</error>')
INSERT [dbo].[ELMAH_Error] ([ErrorId], [Application], [Host], [Type], [Source], [Message], [User], [StatusCode], [TimeUtc], [Sequence], [AllXml]) VALUES (N'05ef5099-9a27-447a-95c1-912fe70fbfc7', N'/LM/W3SVC/3/ROOT', N'JFVALEROSO-PC', N'System.Web.HttpException', N'System.Web.Mvc', N'A public action method ''Register'' was not found on controller ''Exchange.Web.Controllers.CustomerController''.', N'jfvaleroso', 404, CAST(0x0000A3050107B429 AS DateTime), 3, N'<error
  application="/LM/W3SVC/3/ROOT"
  host="JFVALEROSO-PC"
  type="System.Web.HttpException"
  message="A public action method ''Register'' was not found on controller ''Exchange.Web.Controllers.CustomerController''."
  source="System.Web.Mvc"
  detail="System.Web.HttpException (0x80004005): A public action method ''Register'' was not found on controller ''Exchange.Web.Controllers.CustomerController''.&#xD;&#xA;   at System.Web.Mvc.Controller.HandleUnknownAction(String actionName)&#xD;&#xA;   at System.Web.Mvc.Controller.&lt;&gt;c__DisplayClass1d.&lt;BeginExecuteCore&gt;b__18(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.&lt;&gt;c__DisplayClass8.&lt;BeginProcessRequest&gt;b__3(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean&amp; completedSynchronously)"
  user="jfvaleroso"
  time="2014-04-06T16:00:06.9622883Z"
  statusCode="404">
  <serverVariables>
    <item
      name="ALL_HTTP">
      <value
        string="HTTP_CONNECTION:keep-alive&#xD;&#xA;HTTP_CONTENT_LENGTH:208&#xD;&#xA;HTTP_CONTENT_TYPE:application/x-www-form-urlencoded; charset=UTF-8&#xD;&#xA;HTTP_ACCEPT:*/*&#xD;&#xA;HTTP_ACCEPT_ENCODING:gzip,deflate,sdch&#xD;&#xA;HTTP_ACCEPT_LANGUAGE:en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;HTTP_COOKIE:glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=OFeHDw4SBGyhtWJPd_uXP6oMPyz7u83GwvecoBAZ2i005XXb4jUYSNZNkEby3jmLDMO00Ds18nyoA-HfrqU1Tqnc1k57p4ZFecErUaaYPj9BD4B7kdBkZr1J-LBZvUgwSwYyabvXIzxaD_h0t4wDGu3YKndKoh5bliozb-fyYh2A6Hv4YJppHRU-LjbhN_GLR5SK46uajBVButYVHp_q6xgW5iLNqEZhGWt2_xd2g368VGk2ACr5v3kMtnWYbjS6csCOq5T9CDEAflLk5oPl8drZjoDKNvvw_GLafoozL_lqtF7wj46BQZ2YrafjHMdDWH1gxHv4TWgKUbxtMUVV1WJfIZGUQ8ykYyy9u2F3ChdQPagrzkFqO1PPhdEbjdvEy47LQ6CA8XXzLlCoM5SaItqO486toMom-W7BFpiVH6jIV1b50Iv0mefsYERqC-ccLGPLJ54ggMleUhJfE29YE-HSp4_pQ8mohZ1dasPu6iu31PnniZKy-mMc3sgMZ1QYWhiIwgDOMzZT6UJt7JNsJyHRESM1&#xD;&#xA;HTTP_HOST:localhost:26079&#xD;&#xA;HTTP_REFERER:http://localhost:26079/Customer/new&#xD;&#xA;HTTP_USER_AGENT:Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;HTTP_GLIMPSE_PARENT_REQUESTID:1ea45a10-55d4-4968-94c8-6955c26261b2&#xD;&#xA;HTTP_ORIGIN:http://localhost:26079&#xD;&#xA;HTTP_X_REQUESTED_WITH:XMLHttpRequest&#xD;&#xA;" />
    </item>
    <item
      name="ALL_RAW">
      <value
        string="Connection: keep-alive&#xD;&#xA;Content-Length: 208&#xD;&#xA;Content-Type: application/x-www-form-urlencoded; charset=UTF-8&#xD;&#xA;Accept: */*&#xD;&#xA;Accept-Encoding: gzip,deflate,sdch&#xD;&#xA;Accept-Language: en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;Cookie: glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=OFeHDw4SBGyhtWJPd_uXP6oMPyz7u83GwvecoBAZ2i005XXb4jUYSNZNkEby3jmLDMO00Ds18nyoA-HfrqU1Tqnc1k57p4ZFecErUaaYPj9BD4B7kdBkZr1J-LBZvUgwSwYyabvXIzxaD_h0t4wDGu3YKndKoh5bliozb-fyYh2A6Hv4YJppHRU-LjbhN_GLR5SK46uajBVButYVHp_q6xgW5iLNqEZhGWt2_xd2g368VGk2ACr5v3kMtnWYbjS6csCOq5T9CDEAflLk5oPl8drZjoDKNvvw_GLafoozL_lqtF7wj46BQZ2YrafjHMdDWH1gxHv4TWgKUbxtMUVV1WJfIZGUQ8ykYyy9u2F3ChdQPagrzkFqO1PPhdEbjdvEy47LQ6CA8XXzLlCoM5SaItqO486toMom-W7BFpiVH6jIV1b50Iv0mefsYERqC-ccLGPLJ54ggMleUhJfE29YE-HSp4_pQ8mohZ1dasPu6iu31PnniZKy-mMc3sgMZ1QYWhiIwgDOMzZT6UJt7JNsJyHRESM1&#xD;&#xA;Host: localhost:26079&#xD;&#xA;Referer: http://localhost:26079/Customer/new&#xD;&#xA;User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;Glimpse-Parent-RequestID: 1ea45a10-55d4-4968-94c8-6955c26261b2&#xD;&#xA;Origin: http://localhost:26079&#xD;&#xA;X-Requested-With: XMLHttpRequest&#xD;&#xA;" />
    </item>
    <item
      name="APPL_MD_PATH">
      <value
        string="/LM/W3SVC/3/ROOT" />
    </item>
    <item
      name="APPL_PHYSICAL_PATH">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\" />
    </item>
    <item
      name="AUTH_TYPE">
      <value
        string="Forms" />
    </item>
    <item
      name="AUTH_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="AUTH_PASSWORD">
      <value
        string="*****" />
    </item>
    <item
      name="LOGON_USER">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="CERT_COOKIE">
      <value
        string="" />
    </item>
    <item
      name="CERT_FLAGS">
      <value
        string="" />
    </item>
    <item
      name="CERT_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERIALNUMBER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CERT_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CONTENT_LENGTH">
      <value
        string="208" />
    </item>
    <item
      name="CONTENT_TYPE">
      <value
        string="application/x-www-form-urlencoded; charset=UTF-8" />
    </item>
    <item
      name="GATEWAY_INTERFACE">
      <value
        string="CGI/1.1" />
    </item>
    <item
      name="HTTPS">
      <value
        string="off" />
    </item>
    <item
      name="HTTPS_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="INSTANCE_ID">
      <value
        string="3" />
    </item>
    <item
      name="INSTANCE_META_PATH">
      <value
        string="/LM/W3SVC/3" />
    </item>
    <item
      name="LOCAL_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="PATH_INFO">
      <value
        string="/Customer/Register" />
    </item>
    <item
      name="PATH_TRANSLATED">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Customer\Register" />
    </item>
    <item
      name="QUERY_STRING">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_HOST">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_PORT">
      <value
        string="43132" />
    </item>
    <item
      name="REQUEST_METHOD">
      <value
        string="POST" />
    </item>
    <item
      name="SCRIPT_NAME">
      <value
        string="/Customer/Register" />
    </item>
    <item
      name="SERVER_NAME">
      <value
        string="localhost" />
    </item>
    <item
      name="SERVER_PORT">
      <value
        string="26079" />
    </item>
    <item
      name="SERVER_PORT_SECURE">
      <value
        string="0" />
    </item>
    <item
      name="SERVER_PROTOCOL">
      <value
        string="HTTP/1.1" />
    </item>
    <item
      name="SERVER_SOFTWARE">
      <value
        string="Microsoft-IIS/8.0" />
    </item>
    <item
      name="URL">
      <value
        string="/Customer/Register" />
    </item>
    <item
      name="HTTP_CONNECTION">
      <value
        string="keep-alive" />
    </item>
    <item
      name="HTTP_CONTENT_LENGTH">
      <value
        string="208" />
    </item>
    <item
      name="HTTP_CONTENT_TYPE">
      <value
        string="application/x-www-form-urlencoded; charset=UTF-8" />
    </item>
    <item
      name="HTTP_ACCEPT">
      <value
        string="*/*" />
    </item>
    <item
      name="HTTP_ACCEPT_ENCODING">
      <value
        string="gzip,deflate,sdch" />
    </item>
    <item
      name="HTTP_ACCEPT_LANGUAGE">
      <value
        string="en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2" />
    </item>
    <item
      name="HTTP_COOKIE">
      <value
        string="glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=OFeHDw4SBGyhtWJPd_uXP6oMPyz7u83GwvecoBAZ2i005XXb4jUYSNZNkEby3jmLDMO00Ds18nyoA-HfrqU1Tqnc1k57p4ZFecErUaaYPj9BD4B7kdBkZr1J-LBZvUgwSwYyabvXIzxaD_h0t4wDGu3YKndKoh5bliozb-fyYh2A6Hv4YJppHRU-LjbhN_GLR5SK46uajBVButYVHp_q6xgW5iLNqEZhGWt2_xd2g368VGk2ACr5v3kMtnWYbjS6csCOq5T9CDEAflLk5oPl8drZjoDKNvvw_GLafoozL_lqtF7wj46BQZ2YrafjHMdDWH1gxHv4TWgKUbxtMUVV1WJfIZGUQ8ykYyy9u2F3ChdQPagrzkFqO1PPhdEbjdvEy47LQ6CA8XXzLlCoM5SaItqO486toMom-W7BFpiVH6jIV1b50Iv0mefsYERqC-ccLGPLJ54ggMleUhJfE29YE-HSp4_pQ8mohZ1dasPu6iu31PnniZKy-mMc3sgMZ1QYWhiIwgDOMzZT6UJt7JNsJyHRESM1" />
    </item>
    <item
      name="HTTP_HOST">
      <value
        string="localhost:26079" />
    </item>
    <item
      name="HTTP_REFERER">
      <value
        string="http://localhost:26079/Customer/new" />
    </item>
    <item
      name="HTTP_USER_AGENT">
      <value
        string="Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36" />
    </item>
    <item
      name="HTTP_GLIMPSE_PARENT_REQUESTID">
      <value
        string="1ea45a10-55d4-4968-94c8-6955c26261b2" />
    </item>
    <item
      name="HTTP_ORIGIN">
      <value
        string="http://localhost:26079" />
    </item>
    <item
      name="HTTP_X_REQUESTED_WITH">
      <value
        string="XMLHttpRequest" />
    </item>
  </serverVariables>
  <form>
    <item
      name="FirstName">
      <value
        string="asdfa" />
    </item>
    <item
      name="MiddleName">
      <value
        string="asfd" />
    </item>
    <item
      name="LastName">
      <value
        string="asfd" />
    </item>
    <item
      name="Gender">
      <value
        string="F" />
    </item>
    <item
      name="BirthDate">
      <value
        string="07/01/2014" />
    </item>
    <item
      name="CellphoneNo">
      <value
        string="09297700762" />
    </item>
    <item
      name="Email">
      <value
        string="jfvaleroso.smart@gmail.com" />
    </item>
    <item
      name="ResidentialAddress">
      <value
        string="asdf" />
    </item>
    <item
      name="OfficeAddress">
      <value
        string="asfd" />
    </item>
    <item
      name="TypeOfID">
      <value
        string="COMPID" />
    </item>
    <item
      name="IDNo">
      <value
        string="34234" />
    </item>
  </form>
  <cookies>
    <item
      name="glimpsePolicy">
      <value
        string="On" />
    </item>
    <item
      name="glimpseOptions">
      <value
        string="%7B%22glimpsePolicy%22%3Anull%7D" />
    </item>
    <item
      name="__RequestVerificationToken">
      <value
        string="4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2" />
    </item>
    <item
      name="glimpseId">
      <value
        string="Chrome 33.0" />
    </item>
    <item
      name=".ASPXAUTH">
      <value
        string="2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA" />
    </item>
    <item
      name="ASP.NET_SessionId">
      <value
        string="ckpwa1rl1tiwbvzghywr4fd0" />
    </item>
    <item
      name=".ASPROLES">
      <value
        string="OFeHDw4SBGyhtWJPd_uXP6oMPyz7u83GwvecoBAZ2i005XXb4jUYSNZNkEby3jmLDMO00Ds18nyoA-HfrqU1Tqnc1k57p4ZFecErUaaYPj9BD4B7kdBkZr1J-LBZvUgwSwYyabvXIzxaD_h0t4wDGu3YKndKoh5bliozb-fyYh2A6Hv4YJppHRU-LjbhN_GLR5SK46uajBVButYVHp_q6xgW5iLNqEZhGWt2_xd2g368VGk2ACr5v3kMtnWYbjS6csCOq5T9CDEAflLk5oPl8drZjoDKNvvw_GLafoozL_lqtF7wj46BQZ2YrafjHMdDWH1gxHv4TWgKUbxtMUVV1WJfIZGUQ8ykYyy9u2F3ChdQPagrzkFqO1PPhdEbjdvEy47LQ6CA8XXzLlCoM5SaItqO486toMom-W7BFpiVH6jIV1b50Iv0mefsYERqC-ccLGPLJ54ggMleUhJfE29YE-HSp4_pQ8mohZ1dasPu6iu31PnniZKy-mMc3sgMZ1QYWhiIwgDOMzZT6UJt7JNsJyHRESM1" />
    </item>
  </cookies>
</error>')
INSERT [dbo].[ELMAH_Error] ([ErrorId], [Application], [Host], [Type], [Source], [Message], [User], [StatusCode], [TimeUtc], [Sequence], [AllXml]) VALUES (N'2b734cb5-f009-4d50-a932-f7c9bd17d4d0', N'/LM/W3SVC/3/ROOT', N'JFVALEROSO-PC', N'System.Web.HttpException', N'System.Web.Mvc', N'A public action method ''Register'' was not found on controller ''Exchange.Web.Controllers.CustomerController''.', N'jfvaleroso', 404, CAST(0x0000A3050107B604 AS DateTime), 4, N'<error
  application="/LM/W3SVC/3/ROOT"
  host="JFVALEROSO-PC"
  type="System.Web.HttpException"
  message="A public action method ''Register'' was not found on controller ''Exchange.Web.Controllers.CustomerController''."
  source="System.Web.Mvc"
  detail="System.Web.HttpException (0x80004005): A public action method ''Register'' was not found on controller ''Exchange.Web.Controllers.CustomerController''.&#xD;&#xA;   at System.Web.Mvc.Controller.HandleUnknownAction(String actionName)&#xD;&#xA;   at System.Web.Mvc.Controller.&lt;&gt;c__DisplayClass1d.&lt;BeginExecuteCore&gt;b__18(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.&lt;&gt;c__DisplayClass8.&lt;BeginProcessRequest&gt;b__3(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean&amp; completedSynchronously)"
  user="jfvaleroso"
  time="2014-04-06T16:00:08.5460979Z"
  statusCode="404">
  <serverVariables>
    <item
      name="ALL_HTTP">
      <value
        string="HTTP_CONNECTION:keep-alive&#xD;&#xA;HTTP_CONTENT_LENGTH:208&#xD;&#xA;HTTP_CONTENT_TYPE:application/x-www-form-urlencoded; charset=UTF-8&#xD;&#xA;HTTP_ACCEPT:*/*&#xD;&#xA;HTTP_ACCEPT_ENCODING:gzip,deflate,sdch&#xD;&#xA;HTTP_ACCEPT_LANGUAGE:en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;HTTP_COOKIE:glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=OFeHDw4SBGyhtWJPd_uXP6oMPyz7u83GwvecoBAZ2i005XXb4jUYSNZNkEby3jmLDMO00Ds18nyoA-HfrqU1Tqnc1k57p4ZFecErUaaYPj9BD4B7kdBkZr1J-LBZvUgwSwYyabvXIzxaD_h0t4wDGu3YKndKoh5bliozb-fyYh2A6Hv4YJppHRU-LjbhN_GLR5SK46uajBVButYVHp_q6xgW5iLNqEZhGWt2_xd2g368VGk2ACr5v3kMtnWYbjS6csCOq5T9CDEAflLk5oPl8drZjoDKNvvw_GLafoozL_lqtF7wj46BQZ2YrafjHMdDWH1gxHv4TWgKUbxtMUVV1WJfIZGUQ8ykYyy9u2F3ChdQPagrzkFqO1PPhdEbjdvEy47LQ6CA8XXzLlCoM5SaItqO486toMom-W7BFpiVH6jIV1b50Iv0mefsYERqC-ccLGPLJ54ggMleUhJfE29YE-HSp4_pQ8mohZ1dasPu6iu31PnniZKy-mMc3sgMZ1QYWhiIwgDOMzZT6UJt7JNsJyHRESM1&#xD;&#xA;HTTP_HOST:localhost:26079&#xD;&#xA;HTTP_REFERER:http://localhost:26079/Customer/new&#xD;&#xA;HTTP_USER_AGENT:Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;HTTP_GLIMPSE_PARENT_REQUESTID:1ea45a10-55d4-4968-94c8-6955c26261b2&#xD;&#xA;HTTP_ORIGIN:http://localhost:26079&#xD;&#xA;HTTP_X_REQUESTED_WITH:XMLHttpRequest&#xD;&#xA;" />
    </item>
    <item
      name="ALL_RAW">
      <value
        string="Connection: keep-alive&#xD;&#xA;Content-Length: 208&#xD;&#xA;Content-Type: application/x-www-form-urlencoded; charset=UTF-8&#xD;&#xA;Accept: */*&#xD;&#xA;Accept-Encoding: gzip,deflate,sdch&#xD;&#xA;Accept-Language: en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;Cookie: glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=OFeHDw4SBGyhtWJPd_uXP6oMPyz7u83GwvecoBAZ2i005XXb4jUYSNZNkEby3jmLDMO00Ds18nyoA-HfrqU1Tqnc1k57p4ZFecErUaaYPj9BD4B7kdBkZr1J-LBZvUgwSwYyabvXIzxaD_h0t4wDGu3YKndKoh5bliozb-fyYh2A6Hv4YJppHRU-LjbhN_GLR5SK46uajBVButYVHp_q6xgW5iLNqEZhGWt2_xd2g368VGk2ACr5v3kMtnWYbjS6csCOq5T9CDEAflLk5oPl8drZjoDKNvvw_GLafoozL_lqtF7wj46BQZ2YrafjHMdDWH1gxHv4TWgKUbxtMUVV1WJfIZGUQ8ykYyy9u2F3ChdQPagrzkFqO1PPhdEbjdvEy47LQ6CA8XXzLlCoM5SaItqO486toMom-W7BFpiVH6jIV1b50Iv0mefsYERqC-ccLGPLJ54ggMleUhJfE29YE-HSp4_pQ8mohZ1dasPu6iu31PnniZKy-mMc3sgMZ1QYWhiIwgDOMzZT6UJt7JNsJyHRESM1&#xD;&#xA;Host: localhost:26079&#xD;&#xA;Referer: http://localhost:26079/Customer/new&#xD;&#xA;User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;Glimpse-Parent-RequestID: 1ea45a10-55d4-4968-94c8-6955c26261b2&#xD;&#xA;Origin: http://localhost:26079&#xD;&#xA;X-Requested-With: XMLHttpRequest&#xD;&#xA;" />
    </item>
    <item
      name="APPL_MD_PATH">
      <value
        string="/LM/W3SVC/3/ROOT" />
    </item>
    <item
      name="APPL_PHYSICAL_PATH">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\" />
    </item>
    <item
      name="AUTH_TYPE">
      <value
        string="Forms" />
    </item>
    <item
      name="AUTH_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="AUTH_PASSWORD">
      <value
        string="*****" />
    </item>
    <item
      name="LOGON_USER">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="CERT_COOKIE">
      <value
        string="" />
    </item>
    <item
      name="CERT_FLAGS">
      <value
        string="" />
    </item>
    <item
      name="CERT_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERIALNUMBER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CERT_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CONTENT_LENGTH">
      <value
        string="208" />
    </item>
    <item
      name="CONTENT_TYPE">
      <value
        string="application/x-www-form-urlencoded; charset=UTF-8" />
    </item>
    <item
      name="GATEWAY_INTERFACE">
      <value
        string="CGI/1.1" />
    </item>
    <item
      name="HTTPS">
      <value
        string="off" />
    </item>
    <item
      name="HTTPS_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="INSTANCE_ID">
      <value
        string="3" />
    </item>
    <item
      name="INSTANCE_META_PATH">
      <value
        string="/LM/W3SVC/3" />
    </item>
    <item
      name="LOCAL_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="PATH_INFO">
      <value
        string="/Customer/Register" />
    </item>
    <item
      name="PATH_TRANSLATED">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Customer\Register" />
    </item>
    <item
      name="QUERY_STRING">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_HOST">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_PORT">
      <value
        string="43132" />
    </item>
    <item
      name="REQUEST_METHOD">
      <value
        string="POST" />
    </item>
    <item
      name="SCRIPT_NAME">
      <value
        string="/Customer/Register" />
    </item>
    <item
      name="SERVER_NAME">
      <value
        string="localhost" />
    </item>
    <item
      name="SERVER_PORT">
      <value
        string="26079" />
    </item>
    <item
      name="SERVER_PORT_SECURE">
      <value
        string="0" />
    </item>
    <item
      name="SERVER_PROTOCOL">
      <value
        string="HTTP/1.1" />
    </item>
    <item
      name="SERVER_SOFTWARE">
      <value
        string="Microsoft-IIS/8.0" />
    </item>
    <item
      name="URL">
      <value
        string="/Customer/Register" />
    </item>
    <item
      name="HTTP_CONNECTION">
      <value
        string="keep-alive" />
    </item>
    <item
      name="HTTP_CONTENT_LENGTH">
      <value
        string="208" />
    </item>
    <item
      name="HTTP_CONTENT_TYPE">
      <value
        string="application/x-www-form-urlencoded; charset=UTF-8" />
    </item>
    <item
      name="HTTP_ACCEPT">
      <value
        string="*/*" />
    </item>
    <item
      name="HTTP_ACCEPT_ENCODING">
      <value
        string="gzip,deflate,sdch" />
    </item>
    <item
      name="HTTP_ACCEPT_LANGUAGE">
      <value
        string="en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2" />
    </item>
    <item
      name="HTTP_COOKIE">
      <value
        string="glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=OFeHDw4SBGyhtWJPd_uXP6oMPyz7u83GwvecoBAZ2i005XXb4jUYSNZNkEby3jmLDMO00Ds18nyoA-HfrqU1Tqnc1k57p4ZFecErUaaYPj9BD4B7kdBkZr1J-LBZvUgwSwYyabvXIzxaD_h0t4wDGu3YKndKoh5bliozb-fyYh2A6Hv4YJppHRU-LjbhN_GLR5SK46uajBVButYVHp_q6xgW5iLNqEZhGWt2_xd2g368VGk2ACr5v3kMtnWYbjS6csCOq5T9CDEAflLk5oPl8drZjoDKNvvw_GLafoozL_lqtF7wj46BQZ2YrafjHMdDWH1gxHv4TWgKUbxtMUVV1WJfIZGUQ8ykYyy9u2F3ChdQPagrzkFqO1PPhdEbjdvEy47LQ6CA8XXzLlCoM5SaItqO486toMom-W7BFpiVH6jIV1b50Iv0mefsYERqC-ccLGPLJ54ggMleUhJfE29YE-HSp4_pQ8mohZ1dasPu6iu31PnniZKy-mMc3sgMZ1QYWhiIwgDOMzZT6UJt7JNsJyHRESM1" />
    </item>
    <item
      name="HTTP_HOST">
      <value
        string="localhost:26079" />
    </item>
    <item
      name="HTTP_REFERER">
      <value
        string="http://localhost:26079/Customer/new" />
    </item>
    <item
      name="HTTP_USER_AGENT">
      <value
        string="Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36" />
    </item>
    <item
      name="HTTP_GLIMPSE_PARENT_REQUESTID">
      <value
        string="1ea45a10-55d4-4968-94c8-6955c26261b2" />
    </item>
    <item
      name="HTTP_ORIGIN">
      <value
        string="http://localhost:26079" />
    </item>
    <item
      name="HTTP_X_REQUESTED_WITH">
      <value
        string="XMLHttpRequest" />
    </item>
  </serverVariables>
  <form>
    <item
      name="FirstName">
      <value
        string="asdfa" />
    </item>
    <item
      name="MiddleName">
      <value
        string="asfd" />
    </item>
    <item
      name="LastName">
      <value
        string="asfd" />
    </item>
    <item
      name="Gender">
      <value
        string="F" />
    </item>
    <item
      name="BirthDate">
      <value
        string="07/01/2014" />
    </item>
    <item
      name="CellphoneNo">
      <value
        string="09297700762" />
    </item>
    <item
      name="Email">
      <value
        string="jfvaleroso.smart@gmail.com" />
    </item>
    <item
      name="ResidentialAddress">
      <value
        string="asdf" />
    </item>
    <item
      name="OfficeAddress">
      <value
        string="asfd" />
    </item>
    <item
      name="TypeOfID">
      <value
        string="COMPID" />
    </item>
    <item
      name="IDNo">
      <value
        string="34234" />
    </item>
  </form>
  <cookies>
    <item
      name="glimpsePolicy">
      <value
        string="On" />
    </item>
    <item
      name="glimpseOptions">
      <value
        string="%7B%22glimpsePolicy%22%3Anull%7D" />
    </item>
    <item
      name="__RequestVerificationToken">
      <value
        string="4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2" />
    </item>
    <item
      name="glimpseId">
      <value
        string="Chrome 33.0" />
    </item>
    <item
      name=".ASPXAUTH">
      <value
        string="2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA" />
    </item>
    <item
      name="ASP.NET_SessionId">
      <value
        string="ckpwa1rl1tiwbvzghywr4fd0" />
    </item>
    <item
      name=".ASPROLES">
      <value
        string="OFeHDw4SBGyhtWJPd_uXP6oMPyz7u83GwvecoBAZ2i005XXb4jUYSNZNkEby3jmLDMO00Ds18nyoA-HfrqU1Tqnc1k57p4ZFecErUaaYPj9BD4B7kdBkZr1J-LBZvUgwSwYyabvXIzxaD_h0t4wDGu3YKndKoh5bliozb-fyYh2A6Hv4YJppHRU-LjbhN_GLR5SK46uajBVButYVHp_q6xgW5iLNqEZhGWt2_xd2g368VGk2ACr5v3kMtnWYbjS6csCOq5T9CDEAflLk5oPl8drZjoDKNvvw_GLafoozL_lqtF7wj46BQZ2YrafjHMdDWH1gxHv4TWgKUbxtMUVV1WJfIZGUQ8ykYyy9u2F3ChdQPagrzkFqO1PPhdEbjdvEy47LQ6CA8XXzLlCoM5SaItqO486toMom-W7BFpiVH6jIV1b50Iv0mefsYERqC-ccLGPLJ54ggMleUhJfE29YE-HSp4_pQ8mohZ1dasPu6iu31PnniZKy-mMc3sgMZ1QYWhiIwgDOMzZT6UJt7JNsJyHRESM1" />
    </item>
  </cookies>
</error>')
INSERT [dbo].[ELMAH_Error] ([ErrorId], [Application], [Host], [Type], [Source], [Message], [User], [StatusCode], [TimeUtc], [Sequence], [AllXml]) VALUES (N'3e73411f-6fa1-49ea-b32f-292c0d8c0b67', N'/LM/W3SVC/3/ROOT', N'JFVALEROSO-PC', N'System.Web.HttpException', N'System.Web.Mvc', N'A public action method ''Register'' was not found on controller ''Exchange.Web.Controllers.CustomerController''.', N'jfvaleroso', 404, CAST(0x0000A30501163B65 AS DateTime), 5, N'<error
  application="/LM/W3SVC/3/ROOT"
  host="JFVALEROSO-PC"
  type="System.Web.HttpException"
  message="A public action method ''Register'' was not found on controller ''Exchange.Web.Controllers.CustomerController''."
  source="System.Web.Mvc"
  detail="System.Web.HttpException (0x80004005): A public action method ''Register'' was not found on controller ''Exchange.Web.Controllers.CustomerController''.&#xD;&#xA;   at System.Web.Mvc.Controller.HandleUnknownAction(String actionName)&#xD;&#xA;   at System.Web.Mvc.Controller.&lt;&gt;c__DisplayClass1d.&lt;BeginExecuteCore&gt;b__18(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.&lt;&gt;c__DisplayClass8.&lt;BeginProcessRequest&gt;b__3(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean&amp; completedSynchronously)"
  user="jfvaleroso"
  time="2014-04-06T16:53:00.7083997Z"
  statusCode="404">
  <serverVariables>
    <item
      name="ALL_HTTP">
      <value
        string="HTTP_CONNECTION:keep-alive&#xD;&#xA;HTTP_CONTENT_LENGTH:265&#xD;&#xA;HTTP_CONTENT_TYPE:application/x-www-form-urlencoded; charset=UTF-8&#xD;&#xA;HTTP_ACCEPT:*/*&#xD;&#xA;HTTP_ACCEPT_ENCODING:gzip,deflate,sdch&#xD;&#xA;HTTP_ACCEPT_LANGUAGE:en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;HTTP_COOKIE:glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=ZawDgCIRMMzz4BPWG6uWa7lVWyHTpzuUzwRxmVzT9EFuCir_uy6UfZTX9Py8O47q5e98x-qAYQnLZh4nPMJAGw-QfAn1rnjn8GH9c4yAhyf0_nUMtzHW2XZe72EVjChoNiktb0_Zbp4HQfT_sV3upq74wg4A9CWBM3fcu_YQuraT1PmfhPXBr_Vbj-532fUK2aq10Lksk9LdDxINekfsghb7JEg-fPGXQlp2sb_pH0pDtk8iR10cYp7NNEfv2kAY60P0uF8VzH7JhiKm_dA7TQLlpnmSOTaUg9WqRj5PGIMQHLOspA-Wca6TbEUprqBzd6MNmohmC64lSSOCzpKcbTRCEEal8RSmWuw00TerBJO0n4jbcL47JCCNpjprmAT9hsvYypCHW6XPNInMXG6Tcal4FyDqAVraTOLwlWo4EcckPg4Si8jBwvEHgvDK42r5Az2n5CsIP4fU4U3M2NujmSf9qAi1FKLqmVdoCwyurIPUlVXNKzI_4U36kAz2fWHC2iXEQm5h2WGvHjysV9jy_juL0wE1&#xD;&#xA;HTTP_HOST:localhost:26079&#xD;&#xA;HTTP_REFERER:http://localhost:26079/Customer/new&#xD;&#xA;HTTP_USER_AGENT:Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;HTTP_GLIMPSE_PARENT_REQUESTID:721ef9a6-ece3-4957-b88b-af8f0565edcc&#xD;&#xA;HTTP_ORIGIN:http://localhost:26079&#xD;&#xA;HTTP_X_REQUESTED_WITH:XMLHttpRequest&#xD;&#xA;" />
    </item>
    <item
      name="ALL_RAW">
      <value
        string="Connection: keep-alive&#xD;&#xA;Content-Length: 265&#xD;&#xA;Content-Type: application/x-www-form-urlencoded; charset=UTF-8&#xD;&#xA;Accept: */*&#xD;&#xA;Accept-Encoding: gzip,deflate,sdch&#xD;&#xA;Accept-Language: en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;Cookie: glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=ZawDgCIRMMzz4BPWG6uWa7lVWyHTpzuUzwRxmVzT9EFuCir_uy6UfZTX9Py8O47q5e98x-qAYQnLZh4nPMJAGw-QfAn1rnjn8GH9c4yAhyf0_nUMtzHW2XZe72EVjChoNiktb0_Zbp4HQfT_sV3upq74wg4A9CWBM3fcu_YQuraT1PmfhPXBr_Vbj-532fUK2aq10Lksk9LdDxINekfsghb7JEg-fPGXQlp2sb_pH0pDtk8iR10cYp7NNEfv2kAY60P0uF8VzH7JhiKm_dA7TQLlpnmSOTaUg9WqRj5PGIMQHLOspA-Wca6TbEUprqBzd6MNmohmC64lSSOCzpKcbTRCEEal8RSmWuw00TerBJO0n4jbcL47JCCNpjprmAT9hsvYypCHW6XPNInMXG6Tcal4FyDqAVraTOLwlWo4EcckPg4Si8jBwvEHgvDK42r5Az2n5CsIP4fU4U3M2NujmSf9qAi1FKLqmVdoCwyurIPUlVXNKzI_4U36kAz2fWHC2iXEQm5h2WGvHjysV9jy_juL0wE1&#xD;&#xA;Host: localhost:26079&#xD;&#xA;Referer: http://localhost:26079/Customer/new&#xD;&#xA;User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;Glimpse-Parent-RequestID: 721ef9a6-ece3-4957-b88b-af8f0565edcc&#xD;&#xA;Origin: http://localhost:26079&#xD;&#xA;X-Requested-With: XMLHttpRequest&#xD;&#xA;" />
    </item>
    <item
      name="APPL_MD_PATH">
      <value
        string="/LM/W3SVC/3/ROOT" />
    </item>
    <item
      name="APPL_PHYSICAL_PATH">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\" />
    </item>
    <item
      name="AUTH_TYPE">
      <value
        string="Forms" />
    </item>
    <item
      name="AUTH_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="AUTH_PASSWORD">
      <value
        string="*****" />
    </item>
    <item
      name="LOGON_USER">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="CERT_COOKIE">
      <value
        string="" />
    </item>
    <item
      name="CERT_FLAGS">
      <value
        string="" />
    </item>
    <item
      name="CERT_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERIALNUMBER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CERT_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CONTENT_LENGTH">
      <value
        string="265" />
    </item>
    <item
      name="CONTENT_TYPE">
      <value
        string="application/x-www-form-urlencoded; charset=UTF-8" />
    </item>
    <item
      name="GATEWAY_INTERFACE">
      <value
        string="CGI/1.1" />
    </item>
    <item
      name="HTTPS">
      <value
        string="off" />
    </item>
    <item
      name="HTTPS_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="INSTANCE_ID">
      <value
        string="3" />
    </item>
    <item
      name="INSTANCE_META_PATH">
      <value
        string="/LM/W3SVC/3" />
    </item>
    <item
      name="LOCAL_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="PATH_INFO">
      <value
        string="/Customer/Register" />
    </item>
    <item
      name="PATH_TRANSLATED">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Customer\Register" />
    </item>
    <item
      name="QUERY_STRING">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_HOST">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_PORT">
      <value
        string="43435" />
    </item>
    <item
      name="REQUEST_METHOD">
      <value
        string="POST" />
    </item>
    <item
      name="SCRIPT_NAME">
      <value
        string="/Customer/Register" />
    </item>
    <item
      name="SERVER_NAME">
      <value
        string="localhost" />
    </item>
    <item
      name="SERVER_PORT">
      <value
        string="26079" />
    </item>
    <item
      name="SERVER_PORT_SECURE">
      <value
        string="0" />
    </item>
    <item
      name="SERVER_PROTOCOL">
      <value
        string="HTTP/1.1" />
    </item>
    <item
      name="SERVER_SOFTWARE">
      <value
        string="Microsoft-IIS/8.0" />
    </item>
    <item
      name="URL">
      <value
        string="/Customer/Register" />
    </item>
    <item
      name="HTTP_CONNECTION">
      <value
        string="keep-alive" />
    </item>
    <item
      name="HTTP_CONTENT_LENGTH">
      <value
        string="265" />
    </item>
    <item
      name="HTTP_CONTENT_TYPE">
      <value
        string="application/x-www-form-urlencoded; charset=UTF-8" />
    </item>
    <item
      name="HTTP_ACCEPT">
      <value
        string="*/*" />
    </item>
    <item
      name="HTTP_ACCEPT_ENCODING">
      <value
        string="gzip,deflate,sdch" />
    </item>
    <item
      name="HTTP_ACCEPT_LANGUAGE">
      <value
        string="en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2" />
    </item>
    <item
      name="HTTP_COOKIE">
      <value
        string="glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=ZawDgCIRMMzz4BPWG6uWa7lVWyHTpzuUzwRxmVzT9EFuCir_uy6UfZTX9Py8O47q5e98x-qAYQnLZh4nPMJAGw-QfAn1rnjn8GH9c4yAhyf0_nUMtzHW2XZe72EVjChoNiktb0_Zbp4HQfT_sV3upq74wg4A9CWBM3fcu_YQuraT1PmfhPXBr_Vbj-532fUK2aq10Lksk9LdDxINekfsghb7JEg-fPGXQlp2sb_pH0pDtk8iR10cYp7NNEfv2kAY60P0uF8VzH7JhiKm_dA7TQLlpnmSOTaUg9WqRj5PGIMQHLOspA-Wca6TbEUprqBzd6MNmohmC64lSSOCzpKcbTRCEEal8RSmWuw00TerBJO0n4jbcL47JCCNpjprmAT9hsvYypCHW6XPNInMXG6Tcal4FyDqAVraTOLwlWo4EcckPg4Si8jBwvEHgvDK42r5Az2n5CsIP4fU4U3M2NujmSf9qAi1FKLqmVdoCwyurIPUlVXNKzI_4U36kAz2fWHC2iXEQm5h2WGvHjysV9jy_juL0wE1" />
    </item>
    <item
      name="HTTP_HOST">
      <value
        string="localhost:26079" />
    </item>
    <item
      name="HTTP_REFERER">
      <value
        string="http://localhost:26079/Customer/new" />
    </item>
    <item
      name="HTTP_USER_AGENT">
      <value
        string="Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36" />
    </item>
    <item
      name="HTTP_GLIMPSE_PARENT_REQUESTID">
      <value
        string="721ef9a6-ece3-4957-b88b-af8f0565edcc" />
    </item>
    <item
      name="HTTP_ORIGIN">
      <value
        string="http://localhost:26079" />
    </item>
    <item
      name="HTTP_X_REQUESTED_WITH">
      <value
        string="XMLHttpRequest" />
    </item>
  </serverVariables>
  <form>
    <item
      name="FirstName">
      <value
        string="jhgjjh" />
    </item>
    <item
      name="MiddleName">
      <value
        string="kjhkj" />
    </item>
    <item
      name="LastName">
      <value
        string="kjhkj" />
    </item>
    <item
      name="Gender">
      <value
        string="M" />
    </item>
    <item
      name="birth[month]">
      <value
        string="3" />
    </item>
    <item
      name="birth[day]">
      <value
        string="5" />
    </item>
    <item
      name="birth[year]">
      <value
        string="1992" />
    </item>
    <item
      name="birthdate">
      <value
        string="1992-03-05" />
      <value
        string="1992-03-05" />
    </item>
    <item
      name="CellphoneNo">
      <value
        string="0989809" />
    </item>
    <item
      name="Email">
      <value
        string="hjghj" />
    </item>
    <item
      name="ResidentialAddress">
      <value
        string="jkhkjhjk" />
    </item>
    <item
      name="OfficeAddress">
      <value
        string="kjhkj" />
    </item>
    <item
      name="TypeOfID">
      <value
        string="COMPID" />
    </item>
    <item
      name="IDNo">
      <value
        string="8980980" />
    </item>
  </form>
  <cookies>
    <item
      name="glimpsePolicy">
      <value
        string="On" />
    </item>
    <item
      name="glimpseOptions">
      <value
        string="%7B%22glimpsePolicy%22%3Anull%7D" />
    </item>
    <item
      name="__RequestVerificationToken">
      <value
        string="4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2" />
    </item>
    <item
      name="glimpseId">
      <value
        string="Chrome 33.0" />
    </item>
    <item
      name=".ASPXAUTH">
      <value
        string="2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA" />
    </item>
    <item
      name="ASP.NET_SessionId">
      <value
        string="ckpwa1rl1tiwbvzghywr4fd0" />
    </item>
    <item
      name=".ASPROLES">
      <value
        string="ZawDgCIRMMzz4BPWG6uWa7lVWyHTpzuUzwRxmVzT9EFuCir_uy6UfZTX9Py8O47q5e98x-qAYQnLZh4nPMJAGw-QfAn1rnjn8GH9c4yAhyf0_nUMtzHW2XZe72EVjChoNiktb0_Zbp4HQfT_sV3upq74wg4A9CWBM3fcu_YQuraT1PmfhPXBr_Vbj-532fUK2aq10Lksk9LdDxINekfsghb7JEg-fPGXQlp2sb_pH0pDtk8iR10cYp7NNEfv2kAY60P0uF8VzH7JhiKm_dA7TQLlpnmSOTaUg9WqRj5PGIMQHLOspA-Wca6TbEUprqBzd6MNmohmC64lSSOCzpKcbTRCEEal8RSmWuw00TerBJO0n4jbcL47JCCNpjprmAT9hsvYypCHW6XPNInMXG6Tcal4FyDqAVraTOLwlWo4EcckPg4Si8jBwvEHgvDK42r5Az2n5CsIP4fU4U3M2NujmSf9qAi1FKLqmVdoCwyurIPUlVXNKzI_4U36kAz2fWHC2iXEQm5h2WGvHjysV9jy_juL0wE1" />
    </item>
  </cookies>
</error>')
INSERT [dbo].[ELMAH_Error] ([ErrorId], [Application], [Host], [Type], [Source], [Message], [User], [StatusCode], [TimeUtc], [Sequence], [AllXml]) VALUES (N'bd4cb1c5-0411-4a1b-a0f7-6fb50454ae7c', N'/LM/W3SVC/3/ROOT', N'JFVALEROSO-PC', N'System.NullReferenceException', N'Exchange.Web', N'Object reference not set to an instance of an object.', N'jfvaleroso', 0, CAST(0x0000A30501168A97 AS DateTime), 6, N'<error
  application="/LM/W3SVC/3/ROOT"
  host="JFVALEROSO-PC"
  type="System.NullReferenceException"
  message="Object reference not set to an instance of an object."
  source="Exchange.Web"
  detail="System.NullReferenceException: Object reference not set to an instance of an object.&#xD;&#xA;   at Exchange.Web.Helper.Common.GetCurrentUserStoreAccess() in c:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Helper\Common.cs:line 45&#xD;&#xA;   at Exchange.Web.Controllers.BuyController.Index() in c:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Controllers\BuyController.cs:line 50&#xD;&#xA;   at lambda_method(Closure , ControllerBase , Object[] )&#xD;&#xA;   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)&#xD;&#xA;   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)&#xD;&#xA;   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.InvokeSynchronousActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass42.&lt;BeginInvokeSynchronousActionMethod&gt;b__41()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass8`1.&lt;BeginSynchronous&gt;b__7(IAsyncResult _)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)&#xD;&#xA;   at Castle.Proxies.AsyncControllerActionInvokerProxy.EndInvokeActionMethod_callback(IAsyncResult asyncResult)&#xD;&#xA;   at Castle.Proxies.Invocations.AsyncControllerActionInvoker_EndInvokeActionMethod.InvokeMethodOnTarget()&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Glimpse.Core.Extensibility.CastleInvocationToAlternateMethodContextAdapter.Proceed()&#xD;&#xA;   at Glimpse.Mvc.AlternateType.AsyncActionInvoker.EndInvokeActionMethod.NewImplementation(IAlternateMethodContext context)&#xD;&#xA;   at Glimpse.Core.Extensibility.AlternateTypeToCastleInterceptorAdapter.Intercept(IInvocation invocation)&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Castle.Proxies.AsyncControllerActionInvokerProxy.EndInvokeActionMethod(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass37.&lt;&gt;c__DisplayClass39.&lt;BeginInvokeActionMethodWithFilters&gt;b__33()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass4f.&lt;InvokeActionMethodFilterAsynchronously&gt;b__49()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass37.&lt;BeginInvokeActionMethodWithFilters&gt;b__36(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass25.&lt;&gt;c__DisplayClass2a.&lt;BeginInvokeAction&gt;b__20()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass25.&lt;BeginInvokeAction&gt;b__22(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.&lt;&gt;c__DisplayClass1d.&lt;BeginExecuteCore&gt;b__18(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.&lt;&gt;c__DisplayClass8.&lt;BeginProcessRequest&gt;b__3(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean&amp; completedSynchronously)"
  user="jfvaleroso"
  time="2014-04-06T16:54:08.2909431Z">
  <serverVariables>
    <item
      name="ALL_HTTP">
      <value
        string="HTTP_CONNECTION:keep-alive&#xD;&#xA;HTTP_ACCEPT:text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8&#xD;&#xA;HTTP_ACCEPT_ENCODING:gzip,deflate,sdch&#xD;&#xA;HTTP_ACCEPT_LANGUAGE:en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;HTTP_COOKIE:glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=ZawDgCIRMMzz4BPWG6uWa7lVWyHTpzuUzwRxmVzT9EFuCir_uy6UfZTX9Py8O47q5e98x-qAYQnLZh4nPMJAGw-QfAn1rnjn8GH9c4yAhyf0_nUMtzHW2XZe72EVjChoNiktb0_Zbp4HQfT_sV3upq74wg4A9CWBM3fcu_YQuraT1PmfhPXBr_Vbj-532fUK2aq10Lksk9LdDxINekfsghb7JEg-fPGXQlp2sb_pH0pDtk8iR10cYp7NNEfv2kAY60P0uF8VzH7JhiKm_dA7TQLlpnmSOTaUg9WqRj5PGIMQHLOspA-Wca6TbEUprqBzd6MNmohmC64lSSOCzpKcbTRCEEal8RSmWuw00TerBJO0n4jbcL47JCCNpjprmAT9hsvYypCHW6XPNInMXG6Tcal4FyDqAVraTOLwlWo4EcckPg4Si8jBwvEHgvDK42r5Az2n5CsIP4fU4U3M2NujmSf9qAi1FKLqmVdoCwyurIPUlVXNKzI_4U36kAz2fWHC2iXEQm5h2WGvHjysV9jy_juL0wE1&#xD;&#xA;HTTP_HOST:localhost:26079&#xD;&#xA;HTTP_REFERER:http://localhost:26079/Customer/new&#xD;&#xA;HTTP_USER_AGENT:Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;" />
    </item>
    <item
      name="ALL_RAW">
      <value
        string="Connection: keep-alive&#xD;&#xA;Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8&#xD;&#xA;Accept-Encoding: gzip,deflate,sdch&#xD;&#xA;Accept-Language: en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;Cookie: glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=ZawDgCIRMMzz4BPWG6uWa7lVWyHTpzuUzwRxmVzT9EFuCir_uy6UfZTX9Py8O47q5e98x-qAYQnLZh4nPMJAGw-QfAn1rnjn8GH9c4yAhyf0_nUMtzHW2XZe72EVjChoNiktb0_Zbp4HQfT_sV3upq74wg4A9CWBM3fcu_YQuraT1PmfhPXBr_Vbj-532fUK2aq10Lksk9LdDxINekfsghb7JEg-fPGXQlp2sb_pH0pDtk8iR10cYp7NNEfv2kAY60P0uF8VzH7JhiKm_dA7TQLlpnmSOTaUg9WqRj5PGIMQHLOspA-Wca6TbEUprqBzd6MNmohmC64lSSOCzpKcbTRCEEal8RSmWuw00TerBJO0n4jbcL47JCCNpjprmAT9hsvYypCHW6XPNInMXG6Tcal4FyDqAVraTOLwlWo4EcckPg4Si8jBwvEHgvDK42r5Az2n5CsIP4fU4U3M2NujmSf9qAi1FKLqmVdoCwyurIPUlVXNKzI_4U36kAz2fWHC2iXEQm5h2WGvHjysV9jy_juL0wE1&#xD;&#xA;Host: localhost:26079&#xD;&#xA;Referer: http://localhost:26079/Customer/new&#xD;&#xA;User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;" />
    </item>
    <item
      name="APPL_MD_PATH">
      <value
        string="/LM/W3SVC/3/ROOT" />
    </item>
    <item
      name="APPL_PHYSICAL_PATH">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\" />
    </item>
    <item
      name="AUTH_TYPE">
      <value
        string="Forms" />
    </item>
    <item
      name="AUTH_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="AUTH_PASSWORD">
      <value
        string="*****" />
    </item>
    <item
      name="LOGON_USER">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="CERT_COOKIE">
      <value
        string="" />
    </item>
    <item
      name="CERT_FLAGS">
      <value
        string="" />
    </item>
    <item
      name="CERT_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERIALNUMBER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CERT_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CONTENT_LENGTH">
      <value
        string="0" />
    </item>
    <item
      name="CONTENT_TYPE">
      <value
        string="" />
    </item>
    <item
      name="GATEWAY_INTERFACE">
      <value
        string="CGI/1.1" />
    </item>
    <item
      name="HTTPS">
      <value
        string="off" />
    </item>
    <item
      name="HTTPS_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="INSTANCE_ID">
      <value
        string="3" />
    </item>
    <item
      name="INSTANCE_META_PATH">
      <value
        string="/LM/W3SVC/3" />
    </item>
    <item
      name="LOCAL_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="PATH_INFO">
      <value
        string="/Buy" />
    </item>
    <item
      name="PATH_TRANSLATED">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Buy" />
    </item>
    <item
      name="QUERY_STRING">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_HOST">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_PORT">
      <value
        string="43435" />
    </item>
    <item
      name="REQUEST_METHOD">
      <value
        string="GET" />
    </item>
    <item
      name="SCRIPT_NAME">
      <value
        string="/Buy" />
    </item>
    <item
      name="SERVER_NAME">
      <value
        string="localhost" />
    </item>
    <item
      name="SERVER_PORT">
      <value
        string="26079" />
    </item>
    <item
      name="SERVER_PORT_SECURE">
      <value
        string="0" />
    </item>
    <item
      name="SERVER_PROTOCOL">
      <value
        string="HTTP/1.1" />
    </item>
    <item
      name="SERVER_SOFTWARE">
      <value
        string="Microsoft-IIS/8.0" />
    </item>
    <item
      name="URL">
      <value
        string="/Buy" />
    </item>
    <item
      name="HTTP_CONNECTION">
      <value
        string="keep-alive" />
    </item>
    <item
      name="HTTP_ACCEPT">
      <value
        string="text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8" />
    </item>
    <item
      name="HTTP_ACCEPT_ENCODING">
      <value
        string="gzip,deflate,sdch" />
    </item>
    <item
      name="HTTP_ACCEPT_LANGUAGE">
      <value
        string="en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2" />
    </item>
    <item
      name="HTTP_COOKIE">
      <value
        string="glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; .ASPXAUTH=2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPROLES=ZawDgCIRMMzz4BPWG6uWa7lVWyHTpzuUzwRxmVzT9EFuCir_uy6UfZTX9Py8O47q5e98x-qAYQnLZh4nPMJAGw-QfAn1rnjn8GH9c4yAhyf0_nUMtzHW2XZe72EVjChoNiktb0_Zbp4HQfT_sV3upq74wg4A9CWBM3fcu_YQuraT1PmfhPXBr_Vbj-532fUK2aq10Lksk9LdDxINekfsghb7JEg-fPGXQlp2sb_pH0pDtk8iR10cYp7NNEfv2kAY60P0uF8VzH7JhiKm_dA7TQLlpnmSOTaUg9WqRj5PGIMQHLOspA-Wca6TbEUprqBzd6MNmohmC64lSSOCzpKcbTRCEEal8RSmWuw00TerBJO0n4jbcL47JCCNpjprmAT9hsvYypCHW6XPNInMXG6Tcal4FyDqAVraTOLwlWo4EcckPg4Si8jBwvEHgvDK42r5Az2n5CsIP4fU4U3M2NujmSf9qAi1FKLqmVdoCwyurIPUlVXNKzI_4U36kAz2fWHC2iXEQm5h2WGvHjysV9jy_juL0wE1" />
    </item>
    <item
      name="HTTP_HOST">
      <value
        string="localhost:26079" />
    </item>
    <item
      name="HTTP_REFERER">
      <value
        string="http://localhost:26079/Customer/new" />
    </item>
    <item
      name="HTTP_USER_AGENT">
      <value
        string="Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36" />
    </item>
  </serverVariables>
  <cookies>
    <item
      name="glimpsePolicy">
      <value
        string="On" />
    </item>
    <item
      name="glimpseOptions">
      <value
        string="%7B%22glimpsePolicy%22%3Anull%7D" />
    </item>
    <item
      name="__RequestVerificationToken">
      <value
        string="4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2" />
    </item>
    <item
      name="glimpseId">
      <value
        string="Chrome 33.0" />
    </item>
    <item
      name=".ASPXAUTH">
      <value
        string="2E4C70B4A45BCD2F36CE2315D49C9781C3E6BFFB3D70E206F215EF91B8B21F7A3FC4E103EAED0D166C23714B998B59997D649218EFDF6735521738C7A60BD61153B0E570BF52BD42AE2AFB969329C9F295D71D3146B7B31E2F6B12FDC65374EF8C33E605C900D6944EDBC8E582911121E23C05CC4565DFBDB6C51A37B41A75190B1A28AA" />
    </item>
    <item
      name="ASP.NET_SessionId">
      <value
        string="ckpwa1rl1tiwbvzghywr4fd0" />
    </item>
    <item
      name=".ASPROLES">
      <value
        string="ZawDgCIRMMzz4BPWG6uWa7lVWyHTpzuUzwRxmVzT9EFuCir_uy6UfZTX9Py8O47q5e98x-qAYQnLZh4nPMJAGw-QfAn1rnjn8GH9c4yAhyf0_nUMtzHW2XZe72EVjChoNiktb0_Zbp4HQfT_sV3upq74wg4A9CWBM3fcu_YQuraT1PmfhPXBr_Vbj-532fUK2aq10Lksk9LdDxINekfsghb7JEg-fPGXQlp2sb_pH0pDtk8iR10cYp7NNEfv2kAY60P0uF8VzH7JhiKm_dA7TQLlpnmSOTaUg9WqRj5PGIMQHLOspA-Wca6TbEUprqBzd6MNmohmC64lSSOCzpKcbTRCEEal8RSmWuw00TerBJO0n4jbcL47JCCNpjprmAT9hsvYypCHW6XPNInMXG6Tcal4FyDqAVraTOLwlWo4EcckPg4Si8jBwvEHgvDK42r5Az2n5CsIP4fU4U3M2NujmSf9qAi1FKLqmVdoCwyurIPUlVXNKzI_4U36kAz2fWHC2iXEQm5h2WGvHjysV9jy_juL0wE1" />
    </item>
  </cookies>
</error>')
INSERT [dbo].[ELMAH_Error] ([ErrorId], [Application], [Host], [Type], [Source], [Message], [User], [StatusCode], [TimeUtc], [Sequence], [AllXml]) VALUES (N'a70037ae-5caa-40d9-ad7c-851a5cda20a8', N'/LM/W3SVC/3/ROOT', N'JFVALEROSO-PC', N'System.NullReferenceException', N'Exchange.Web', N'Object reference not set to an instance of an object.', N'jfvaleroso', 0, CAST(0x0000A30600FCB9FD AS DateTime), 7, N'<error
  application="/LM/W3SVC/3/ROOT"
  host="JFVALEROSO-PC"
  type="System.NullReferenceException"
  message="Object reference not set to an instance of an object."
  source="Exchange.Web"
  detail="System.NullReferenceException: Object reference not set to an instance of an object.&#xD;&#xA;   at Exchange.Web.Helper.Common.GetCurrentUserStoreAccess() in c:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Helper\Common.cs:line 45&#xD;&#xA;   at Exchange.Web.Controllers.BuyController.Index() in c:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Controllers\BuyController.cs:line 50&#xD;&#xA;   at lambda_method(Closure , ControllerBase , Object[] )&#xD;&#xA;   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)&#xD;&#xA;   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)&#xD;&#xA;   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.InvokeSynchronousActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass42.&lt;BeginInvokeSynchronousActionMethod&gt;b__41()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass8`1.&lt;BeginSynchronous&gt;b__7(IAsyncResult _)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)&#xD;&#xA;   at Castle.Proxies.AsyncControllerActionInvokerProxy.EndInvokeActionMethod_callback(IAsyncResult asyncResult)&#xD;&#xA;   at Castle.Proxies.Invocations.AsyncControllerActionInvoker_EndInvokeActionMethod.InvokeMethodOnTarget()&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Glimpse.Core.Extensibility.CastleInvocationToAlternateMethodContextAdapter.Proceed()&#xD;&#xA;   at Glimpse.Mvc.AlternateType.AsyncActionInvoker.EndInvokeActionMethod.NewImplementation(IAlternateMethodContext context)&#xD;&#xA;   at Glimpse.Core.Extensibility.AlternateTypeToCastleInterceptorAdapter.Intercept(IInvocation invocation)&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Castle.Proxies.AsyncControllerActionInvokerProxy.EndInvokeActionMethod(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass37.&lt;&gt;c__DisplayClass39.&lt;BeginInvokeActionMethodWithFilters&gt;b__33()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass4f.&lt;InvokeActionMethodFilterAsynchronously&gt;b__49()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass37.&lt;BeginInvokeActionMethodWithFilters&gt;b__36(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass25.&lt;&gt;c__DisplayClass2a.&lt;BeginInvokeAction&gt;b__20()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass25.&lt;BeginInvokeAction&gt;b__22(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.&lt;&gt;c__DisplayClass1d.&lt;BeginExecuteCore&gt;b__18(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.&lt;&gt;c__DisplayClass8.&lt;BeginProcessRequest&gt;b__3(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean&amp; completedSynchronously)"
  user="jfvaleroso"
  time="2014-04-07T15:20:08.9505815Z">
  <serverVariables>
    <item
      name="ALL_HTTP">
      <value
        string="HTTP_CONNECTION:keep-alive&#xD;&#xA;HTTP_ACCEPT:text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8&#xD;&#xA;HTTP_ACCEPT_ENCODING:gzip,deflate,sdch&#xD;&#xA;HTTP_ACCEPT_LANGUAGE:en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;HTTP_COOKIE:glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPXAUTH=020C0B4FC6855238A0ADC9B6BA84DCDE6858D796253D69A9C8B20F25238B251F4C998A644E0C7E13A907F0CC36516B061E7F79CD14BA9835C551AA02AF2D21F9B575026D676DCD3EDC4ABA5815A161727801062F6DDD8602C834910EF09B47077E5904B6743409E6953F233BB328F47179552833D48BC7D0CC3FB00E4337FA15ED6C9972; .ASPROLES=Jb4xKtliQPic_u4zT2TRvbuDE_suSrkx-HoepaICkpmbQc107iJr72fd33xefkU-XePJGtRAeVmJTFhHYEQx-cI4CIeBYbuP5UeyBNVnmAlDFggRufRqB8ZSzS5XkJp4cvqnuG6yWFe_hr8GxWGeJ02jtMYfLo9fH0-dS_TtfAD_e66onOlON-D7PQaIjQK6ACNBEWo0VbNtYUEYnaMfRUOlO4qamMP_5xQwMfM-doFLGwk1I7BgehLHJHzHGi989X4DqlsbOX0gLpXdi8fUg58N9gtwWDzlkQoDIkUDby1IVEOWtVFEhDymWi7roPGJ3h4xyf7oHcg4Ebqwz4BCWjV6UmU8w4io5RcmjXmxl3xupk8qlsDM9oTgQextbKvTZVARltp-R_jfA0EVQ1QP5oiKwOMvpgWe2qaBauR5eWkAdbwV2m2alTnovqwmK5FHwcHRuhTjbqnI4uKQfDTeFA6hjTcU__6RLLzscxQ4JWyooWPGkYpZrShEAYTtzjygdBr0-zNknxQqrZpVr8PvTMJ-xqQ1&#xD;&#xA;HTTP_HOST:localhost:26079&#xD;&#xA;HTTP_REFERER:http://localhost:26079/&#xD;&#xA;HTTP_USER_AGENT:Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;" />
    </item>
    <item
      name="ALL_RAW">
      <value
        string="Connection: keep-alive&#xD;&#xA;Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8&#xD;&#xA;Accept-Encoding: gzip,deflate,sdch&#xD;&#xA;Accept-Language: en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;Cookie: glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPXAUTH=020C0B4FC6855238A0ADC9B6BA84DCDE6858D796253D69A9C8B20F25238B251F4C998A644E0C7E13A907F0CC36516B061E7F79CD14BA9835C551AA02AF2D21F9B575026D676DCD3EDC4ABA5815A161727801062F6DDD8602C834910EF09B47077E5904B6743409E6953F233BB328F47179552833D48BC7D0CC3FB00E4337FA15ED6C9972; .ASPROLES=Jb4xKtliQPic_u4zT2TRvbuDE_suSrkx-HoepaICkpmbQc107iJr72fd33xefkU-XePJGtRAeVmJTFhHYEQx-cI4CIeBYbuP5UeyBNVnmAlDFggRufRqB8ZSzS5XkJp4cvqnuG6yWFe_hr8GxWGeJ02jtMYfLo9fH0-dS_TtfAD_e66onOlON-D7PQaIjQK6ACNBEWo0VbNtYUEYnaMfRUOlO4qamMP_5xQwMfM-doFLGwk1I7BgehLHJHzHGi989X4DqlsbOX0gLpXdi8fUg58N9gtwWDzlkQoDIkUDby1IVEOWtVFEhDymWi7roPGJ3h4xyf7oHcg4Ebqwz4BCWjV6UmU8w4io5RcmjXmxl3xupk8qlsDM9oTgQextbKvTZVARltp-R_jfA0EVQ1QP5oiKwOMvpgWe2qaBauR5eWkAdbwV2m2alTnovqwmK5FHwcHRuhTjbqnI4uKQfDTeFA6hjTcU__6RLLzscxQ4JWyooWPGkYpZrShEAYTtzjygdBr0-zNknxQqrZpVr8PvTMJ-xqQ1&#xD;&#xA;Host: localhost:26079&#xD;&#xA;Referer: http://localhost:26079/&#xD;&#xA;User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;" />
    </item>
    <item
      name="APPL_MD_PATH">
      <value
        string="/LM/W3SVC/3/ROOT" />
    </item>
    <item
      name="APPL_PHYSICAL_PATH">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\" />
    </item>
    <item
      name="AUTH_TYPE">
      <value
        string="Forms" />
    </item>
    <item
      name="AUTH_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="AUTH_PASSWORD">
      <value
        string="*****" />
    </item>
    <item
      name="LOGON_USER">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_USER">
      <value
        string="jfvaleroso" />
    </item>
    <item
      name="CERT_COOKIE">
      <value
        string="" />
    </item>
    <item
      name="CERT_FLAGS">
      <value
        string="" />
    </item>
    <item
      name="CERT_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERIALNUMBER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CERT_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CONTENT_LENGTH">
      <value
        string="0" />
    </item>
    <item
      name="CONTENT_TYPE">
      <value
        string="" />
    </item>
    <item
      name="GATEWAY_INTERFACE">
      <value
        string="CGI/1.1" />
    </item>
    <item
      name="HTTPS">
      <value
        string="off" />
    </item>
    <item
      name="HTTPS_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="INSTANCE_ID">
      <value
        string="3" />
    </item>
    <item
      name="INSTANCE_META_PATH">
      <value
        string="/LM/W3SVC/3" />
    </item>
    <item
      name="LOCAL_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="PATH_INFO">
      <value
        string="/Buy" />
    </item>
    <item
      name="PATH_TRANSLATED">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Buy" />
    </item>
    <item
      name="QUERY_STRING">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_HOST">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_PORT">
      <value
        string="44641" />
    </item>
    <item
      name="REQUEST_METHOD">
      <value
        string="GET" />
    </item>
    <item
      name="SCRIPT_NAME">
      <value
        string="/Buy" />
    </item>
    <item
      name="SERVER_NAME">
      <value
        string="localhost" />
    </item>
    <item
      name="SERVER_PORT">
      <value
        string="26079" />
    </item>
    <item
      name="SERVER_PORT_SECURE">
      <value
        string="0" />
    </item>
    <item
      name="SERVER_PROTOCOL">
      <value
        string="HTTP/1.1" />
    </item>
    <item
      name="SERVER_SOFTWARE">
      <value
        string="Microsoft-IIS/8.0" />
    </item>
    <item
      name="URL">
      <value
        string="/Buy" />
    </item>
    <item
      name="HTTP_CONNECTION">
      <value
        string="keep-alive" />
    </item>
    <item
      name="HTTP_ACCEPT">
      <value
        string="text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8" />
    </item>
    <item
      name="HTTP_ACCEPT_ENCODING">
      <value
        string="gzip,deflate,sdch" />
    </item>
    <item
      name="HTTP_ACCEPT_LANGUAGE">
      <value
        string="en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2" />
    </item>
    <item
      name="HTTP_COOKIE">
      <value
        string="glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2; glimpseId=Chrome 33.0; ASP.NET_SessionId=ckpwa1rl1tiwbvzghywr4fd0; .ASPXAUTH=020C0B4FC6855238A0ADC9B6BA84DCDE6858D796253D69A9C8B20F25238B251F4C998A644E0C7E13A907F0CC36516B061E7F79CD14BA9835C551AA02AF2D21F9B575026D676DCD3EDC4ABA5815A161727801062F6DDD8602C834910EF09B47077E5904B6743409E6953F233BB328F47179552833D48BC7D0CC3FB00E4337FA15ED6C9972; .ASPROLES=Jb4xKtliQPic_u4zT2TRvbuDE_suSrkx-HoepaICkpmbQc107iJr72fd33xefkU-XePJGtRAeVmJTFhHYEQx-cI4CIeBYbuP5UeyBNVnmAlDFggRufRqB8ZSzS5XkJp4cvqnuG6yWFe_hr8GxWGeJ02jtMYfLo9fH0-dS_TtfAD_e66onOlON-D7PQaIjQK6ACNBEWo0VbNtYUEYnaMfRUOlO4qamMP_5xQwMfM-doFLGwk1I7BgehLHJHzHGi989X4DqlsbOX0gLpXdi8fUg58N9gtwWDzlkQoDIkUDby1IVEOWtVFEhDymWi7roPGJ3h4xyf7oHcg4Ebqwz4BCWjV6UmU8w4io5RcmjXmxl3xupk8qlsDM9oTgQextbKvTZVARltp-R_jfA0EVQ1QP5oiKwOMvpgWe2qaBauR5eWkAdbwV2m2alTnovqwmK5FHwcHRuhTjbqnI4uKQfDTeFA6hjTcU__6RLLzscxQ4JWyooWPGkYpZrShEAYTtzjygdBr0-zNknxQqrZpVr8PvTMJ-xqQ1" />
    </item>
    <item
      name="HTTP_HOST">
      <value
        string="localhost:26079" />
    </item>
    <item
      name="HTTP_REFERER">
      <value
        string="http://localhost:26079/" />
    </item>
    <item
      name="HTTP_USER_AGENT">
      <value
        string="Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36" />
    </item>
  </serverVariables>
  <cookies>
    <item
      name="glimpsePolicy">
      <value
        string="On" />
    </item>
    <item
      name="glimpseOptions">
      <value
        string="%7B%22glimpsePolicy%22%3Anull%7D" />
    </item>
    <item
      name="__RequestVerificationToken">
      <value
        string="4-QGrOF4ZNCfHaIhGdIJHwP3s-S4lXoDz2hu17r_APEtAlUbZgDUJrh0hhU-X5blMFzpkfJAI_NivIEkrLmmKi1PtmvzgvrC7yPkxTBwJ18lZS44h4cF25dWD83GPtO1vzkehw2" />
    </item>
    <item
      name="glimpseId">
      <value
        string="Chrome 33.0" />
    </item>
    <item
      name="ASP.NET_SessionId">
      <value
        string="ckpwa1rl1tiwbvzghywr4fd0" />
    </item>
    <item
      name=".ASPXAUTH">
      <value
        string="020C0B4FC6855238A0ADC9B6BA84DCDE6858D796253D69A9C8B20F25238B251F4C998A644E0C7E13A907F0CC36516B061E7F79CD14BA9835C551AA02AF2D21F9B575026D676DCD3EDC4ABA5815A161727801062F6DDD8602C834910EF09B47077E5904B6743409E6953F233BB328F47179552833D48BC7D0CC3FB00E4337FA15ED6C9972" />
    </item>
    <item
      name=".ASPROLES">
      <value
        string="Jb4xKtliQPic_u4zT2TRvbuDE_suSrkx-HoepaICkpmbQc107iJr72fd33xefkU-XePJGtRAeVmJTFhHYEQx-cI4CIeBYbuP5UeyBNVnmAlDFggRufRqB8ZSzS5XkJp4cvqnuG6yWFe_hr8GxWGeJ02jtMYfLo9fH0-dS_TtfAD_e66onOlON-D7PQaIjQK6ACNBEWo0VbNtYUEYnaMfRUOlO4qamMP_5xQwMfM-doFLGwk1I7BgehLHJHzHGi989X4DqlsbOX0gLpXdi8fUg58N9gtwWDzlkQoDIkUDby1IVEOWtVFEhDymWi7roPGJ3h4xyf7oHcg4Ebqwz4BCWjV6UmU8w4io5RcmjXmxl3xupk8qlsDM9oTgQextbKvTZVARltp-R_jfA0EVQ1QP5oiKwOMvpgWe2qaBauR5eWkAdbwV2m2alTnovqwmK5FHwcHRuhTjbqnI4uKQfDTeFA6hjTcU__6RLLzscxQ4JWyooWPGkYpZrShEAYTtzjygdBr0-zNknxQqrZpVr8PvTMJ-xqQ1" />
    </item>
  </cookies>
</error>')
INSERT [dbo].[ELMAH_Error] ([ErrorId], [Application], [Host], [Type], [Source], [Message], [User], [StatusCode], [TimeUtc], [Sequence], [AllXml]) VALUES (N'434785c2-b974-4868-b20b-c6101eabf72d', N'/LM/W3SVC/3/ROOT', N'JFVALEROSO-PC', N'NHibernate.QueryException', N'NHibernate', N'could not resolve property: Product of: Exchange.Core.Entities.Product', N'', 0, CAST(0x0000A30900FEB8AF AS DateTime), 8, N'<error
  application="/LM/W3SVC/3/ROOT"
  host="JFVALEROSO-PC"
  type="NHibernate.QueryException"
  message="could not resolve property: Product of: Exchange.Core.Entities.Product"
  source="NHibernate"
  detail="NHibernate.QueryException: could not resolve property: Product of: Exchange.Core.Entities.Product&#xD;&#xA;   at NHibernate.Persister.Entity.AbstractPropertyMapping.ToType(String propertyName)&#xD;&#xA;   at NHibernate.Persister.Entity.AbstractEntityPersister.ToType(String propertyName)&#xD;&#xA;   at NHibernate.Loader.Criteria.EntityCriteriaInfoProvider.GetType(String relativePath)&#xD;&#xA;   at NHibernate.Loader.Criteria.CriteriaQueryTranslator.GetPathInfo(String path)&#xD;&#xA;   at NHibernate.Loader.Criteria.CriteriaQueryTranslator.CreateCriteriaEntityNameMap()&#xD;&#xA;   at NHibernate.Loader.Criteria.CriteriaQueryTranslator..ctor(ISessionFactoryImplementor factory, CriteriaImpl criteria, String rootEntityName, String rootSQLAlias)&#xD;&#xA;   at NHibernate.Loader.Criteria.CriteriaLoader..ctor(IOuterJoinLoadable persister, ISessionFactoryImplementor factory, CriteriaImpl rootCriteria, String rootEntityName, IDictionary`2 enabledFilters)&#xD;&#xA;   at NHibernate.Impl.MultiCriteriaImpl.CreateCriteriaLoaders()&#xD;&#xA;   at NHibernate.Impl.MultiCriteriaImpl.List()&#xD;&#xA;   at NHibernate.Impl.FutureCriteriaBatch.GetResultsFrom(IMultiCriteria multiApproach)&#xD;&#xA;   at NHibernate.Impl.FutureBatch`2.GetResults()&#xD;&#xA;   at NHibernate.Impl.FutureBatch`2.get_Results()&#xD;&#xA;   at NHibernate.Impl.FutureBatch`2.GetCurrentResult[TResult](Int32 currentIndex)&#xD;&#xA;   at NHibernate.Impl.FutureBatch`2.&lt;&gt;c__DisplayClass4`1.&lt;GetEnumerator&gt;b__3()&#xD;&#xA;   at NHibernate.Impl.DelayedEnumerator`1.&lt;get_Enumerable&gt;d__0.MoveNext()&#xD;&#xA;   at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)&#xD;&#xA;   at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)&#xD;&#xA;   at Exchange.NHibernateBase.Repositories.NHRepositoryBase`2.Test(List`1 criterion, Dictionary`2 aliases, List`1 orders) in c:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.NHibernate\Repositories\NHRepositoryBase.cs:line 214&#xD;&#xA;   at Exchange.NHibernateBase.Repositories.NHProductRepository.Test() in c:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.NHibernate\Repositories\NHProductRepository.cs:line 24&#xD;&#xA;   at Castle.Proxies.Invocations.IProductRepository_Test.InvokeMethodOnTarget()&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Exchange.Dependency.UnitOfWork.NHUnitOfWorkInterceptor.Intercept(IInvocation invocation) in c:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Dependency\UnitOfWork\NHUnitOfWorkInterceptor.cs:line 68&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Castle.Proxies.IProductRepositoryProxy.Test()&#xD;&#xA;   at Exchange.Core.Services.Implementation.ProductService.GetAllData() in c:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Core\Services\Implementation\ProductService.cs:line 75&#xD;&#xA;   at Castle.Proxies.Invocations.IService`2_GetAllData.InvokeMethodOnTarget()&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Exchange.Dependency.UnitOfWork.NHUnitOfWorkInterceptor.Intercept(IInvocation invocation) in c:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Dependency\UnitOfWork\NHUnitOfWorkInterceptor.cs:line 37&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Castle.Proxies.IProductServiceProxy.GetAllData()&#xD;&#xA;   at Exchange.Web.Areas.Admin.Controllers.ProductController.Index() in c:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Areas\Admin\Controllers\ProductController.cs:line 36&#xD;&#xA;   at lambda_method(Closure , ControllerBase , Object[] )&#xD;&#xA;   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)&#xD;&#xA;   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)&#xD;&#xA;   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.InvokeSynchronousActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass42.&lt;BeginInvokeSynchronousActionMethod&gt;b__41()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass8`1.&lt;BeginSynchronous&gt;b__7(IAsyncResult _)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)&#xD;&#xA;   at Castle.Proxies.AsyncControllerActionInvokerProxy.EndInvokeActionMethod_callback(IAsyncResult asyncResult)&#xD;&#xA;   at Castle.Proxies.Invocations.AsyncControllerActionInvoker_EndInvokeActionMethod.InvokeMethodOnTarget()&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Glimpse.Core.Extensibility.CastleInvocationToAlternateMethodContextAdapter.Proceed()&#xD;&#xA;   at Glimpse.Mvc.AlternateType.AsyncActionInvoker.EndInvokeActionMethod.NewImplementation(IAlternateMethodContext context)&#xD;&#xA;   at Glimpse.Core.Extensibility.AlternateTypeToCastleInterceptorAdapter.Intercept(IInvocation invocation)&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Castle.Proxies.AsyncControllerActionInvokerProxy.EndInvokeActionMethod(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass37.&lt;&gt;c__DisplayClass39.&lt;BeginInvokeActionMethodWithFilters&gt;b__33()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass4f.&lt;InvokeActionMethodFilterAsynchronously&gt;b__49()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass37.&lt;BeginInvokeActionMethodWithFilters&gt;b__36(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass25.&lt;&gt;c__DisplayClass2a.&lt;BeginInvokeAction&gt;b__20()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass25.&lt;BeginInvokeAction&gt;b__22(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.&lt;&gt;c__DisplayClass1d.&lt;BeginExecuteCore&gt;b__18(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.&lt;&gt;c__DisplayClass8.&lt;BeginProcessRequest&gt;b__3(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean&amp; completedSynchronously)"
  time="2014-04-10T15:27:24.7422776Z">
  <serverVariables>
    <item
      name="ALL_HTTP">
      <value
        string="HTTP_CONNECTION:keep-alive&#xD;&#xA;HTTP_ACCEPT:text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8&#xD;&#xA;HTTP_ACCEPT_ENCODING:gzip,deflate,sdch&#xD;&#xA;HTTP_ACCEPT_LANGUAGE:en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;HTTP_COOKIE:glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=DcesC7SwWm8gtsTOxwdaEWMtGeEh5wYTvUjfOhFo79yrPtml06GGOQYL6mhe5IfqhUyYWhqDtMkdiLn-2MMmjDnfQAu0gzr0CPaKWRcjf-a3_ypCVWgnQALZif34nXRjsLimTA2; glimpseId=Chrome 33.0&#xD;&#xA;HTTP_HOST:localhost:26079&#xD;&#xA;HTTP_REFERER:http://localhost:26079/Admin/Maintenance&#xD;&#xA;HTTP_USER_AGENT:Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;" />
    </item>
    <item
      name="ALL_RAW">
      <value
        string="Connection: keep-alive&#xD;&#xA;Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8&#xD;&#xA;Accept-Encoding: gzip,deflate,sdch&#xD;&#xA;Accept-Language: en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;Cookie: glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=DcesC7SwWm8gtsTOxwdaEWMtGeEh5wYTvUjfOhFo79yrPtml06GGOQYL6mhe5IfqhUyYWhqDtMkdiLn-2MMmjDnfQAu0gzr0CPaKWRcjf-a3_ypCVWgnQALZif34nXRjsLimTA2; glimpseId=Chrome 33.0&#xD;&#xA;Host: localhost:26079&#xD;&#xA;Referer: http://localhost:26079/Admin/Maintenance&#xD;&#xA;User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;" />
    </item>
    <item
      name="APPL_MD_PATH">
      <value
        string="/LM/W3SVC/3/ROOT" />
    </item>
    <item
      name="APPL_PHYSICAL_PATH">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\" />
    </item>
    <item
      name="AUTH_TYPE">
      <value
        string="" />
    </item>
    <item
      name="AUTH_USER">
      <value
        string="" />
    </item>
    <item
      name="AUTH_PASSWORD">
      <value
        string="*****" />
    </item>
    <item
      name="LOGON_USER">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_USER">
      <value
        string="" />
    </item>
    <item
      name="CERT_COOKIE">
      <value
        string="" />
    </item>
    <item
      name="CERT_FLAGS">
      <value
        string="" />
    </item>
    <item
      name="CERT_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERIALNUMBER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CERT_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CONTENT_LENGTH">
      <value
        string="0" />
    </item>
    <item
      name="CONTENT_TYPE">
      <value
        string="" />
    </item>
    <item
      name="GATEWAY_INTERFACE">
      <value
        string="CGI/1.1" />
    </item>
    <item
      name="HTTPS">
      <value
        string="off" />
    </item>
    <item
      name="HTTPS_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="INSTANCE_ID">
      <value
        string="3" />
    </item>
    <item
      name="INSTANCE_META_PATH">
      <value
        string="/LM/W3SVC/3" />
    </item>
    <item
      name="LOCAL_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="PATH_INFO">
      <value
        string="/Admin/Product" />
    </item>
    <item
      name="PATH_TRANSLATED">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Admin\Product" />
    </item>
    <item
      name="QUERY_STRING">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_HOST">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_PORT">
      <value
        string="6106" />
    </item>
    <item
      name="REQUEST_METHOD">
      <value
        string="GET" />
    </item>
    <item
      name="SCRIPT_NAME">
      <value
        string="/Admin/Product" />
    </item>
    <item
      name="SERVER_NAME">
      <value
        string="localhost" />
    </item>
    <item
      name="SERVER_PORT">
      <value
        string="26079" />
    </item>
    <item
      name="SERVER_PORT_SECURE">
      <value
        string="0" />
    </item>
    <item
      name="SERVER_PROTOCOL">
      <value
        string="HTTP/1.1" />
    </item>
    <item
      name="SERVER_SOFTWARE">
      <value
        string="Microsoft-IIS/8.0" />
    </item>
    <item
      name="URL">
      <value
        string="/Admin/Product" />
    </item>
    <item
      name="HTTP_CONNECTION">
      <value
        string="keep-alive" />
    </item>
    <item
      name="HTTP_ACCEPT">
      <value
        string="text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8" />
    </item>
    <item
      name="HTTP_ACCEPT_ENCODING">
      <value
        string="gzip,deflate,sdch" />
    </item>
    <item
      name="HTTP_ACCEPT_LANGUAGE">
      <value
        string="en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2" />
    </item>
    <item
      name="HTTP_COOKIE">
      <value
        string="glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=DcesC7SwWm8gtsTOxwdaEWMtGeEh5wYTvUjfOhFo79yrPtml06GGOQYL6mhe5IfqhUyYWhqDtMkdiLn-2MMmjDnfQAu0gzr0CPaKWRcjf-a3_ypCVWgnQALZif34nXRjsLimTA2; glimpseId=Chrome 33.0" />
    </item>
    <item
      name="HTTP_HOST">
      <value
        string="localhost:26079" />
    </item>
    <item
      name="HTTP_REFERER">
      <value
        string="http://localhost:26079/Admin/Maintenance" />
    </item>
    <item
      name="HTTP_USER_AGENT">
      <value
        string="Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36" />
    </item>
  </serverVariables>
  <cookies>
    <item
      name="glimpsePolicy">
      <value
        string="On" />
    </item>
    <item
      name="glimpseOptions">
      <value
        string="%7B%22glimpsePolicy%22%3Anull%7D" />
    </item>
    <item
      name="__RequestVerificationToken">
      <value
        string="DcesC7SwWm8gtsTOxwdaEWMtGeEh5wYTvUjfOhFo79yrPtml06GGOQYL6mhe5IfqhUyYWhqDtMkdiLn-2MMmjDnfQAu0gzr0CPaKWRcjf-a3_ypCVWgnQALZif34nXRjsLimTA2" />
    </item>
    <item
      name="glimpseId">
      <value
        string="Chrome 33.0" />
    </item>
  </cookies>
</error>')
INSERT [dbo].[ELMAH_Error] ([ErrorId], [Application], [Host], [Type], [Source], [Message], [User], [StatusCode], [TimeUtc], [Sequence], [AllXml]) VALUES (N'94675825-93fd-4ff5-bef2-6eb9e311b24a', N'/LM/W3SVC/3/ROOT', N'JFVALEROSO-PC', N'System.NullReferenceException', N'Exchange.Web', N'Object reference not set to an instance of an object.', N'', 0, CAST(0x0000A309010064A7 AS DateTime), 9, N'<error
  application="/LM/W3SVC/3/ROOT"
  host="JFVALEROSO-PC"
  type="System.NullReferenceException"
  message="Object reference not set to an instance of an object."
  source="Exchange.Web"
  detail="System.NullReferenceException: Object reference not set to an instance of an object.&#xD;&#xA;   at Exchange.Web.Areas.Admin.Controllers.ProductController.&lt;ProductListWithPaging&gt;b__0(Product x) in c:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Areas\Admin\Controllers\ProductController.cs:line 45&#xD;&#xA;   at System.Linq.Enumerable.WhereSelectListIterator`2.MoveNext()&#xD;&#xA;   at System.Web.Script.Serialization.JavaScriptSerializer.SerializeEnumerable(IEnumerable enumerable, StringBuilder sb, Int32 depth, Hashtable objectsInUse, SerializationFormat serializationFormat)&#xD;&#xA;   at System.Web.Script.Serialization.JavaScriptSerializer.SerializeValueInternal(Object o, StringBuilder sb, Int32 depth, Hashtable objectsInUse, SerializationFormat serializationFormat, MemberInfo currentMember)&#xD;&#xA;   at System.Web.Script.Serialization.JavaScriptSerializer.SerializeValue(Object o, StringBuilder sb, Int32 depth, Hashtable objectsInUse, SerializationFormat serializationFormat, MemberInfo currentMember)&#xD;&#xA;   at System.Web.Script.Serialization.JavaScriptSerializer.SerializeCustomObject(Object o, StringBuilder sb, Int32 depth, Hashtable objectsInUse, SerializationFormat serializationFormat)&#xD;&#xA;   at System.Web.Script.Serialization.JavaScriptSerializer.SerializeValueInternal(Object o, StringBuilder sb, Int32 depth, Hashtable objectsInUse, SerializationFormat serializationFormat, MemberInfo currentMember)&#xD;&#xA;   at System.Web.Script.Serialization.JavaScriptSerializer.SerializeValue(Object o, StringBuilder sb, Int32 depth, Hashtable objectsInUse, SerializationFormat serializationFormat, MemberInfo currentMember)&#xD;&#xA;   at System.Web.Script.Serialization.JavaScriptSerializer.Serialize(Object obj, StringBuilder output, SerializationFormat serializationFormat)&#xD;&#xA;   at System.Web.Script.Serialization.JavaScriptSerializer.Serialize(Object obj, SerializationFormat serializationFormat)&#xD;&#xA;   at System.Web.Script.Serialization.JavaScriptSerializer.Serialize(Object obj)&#xD;&#xA;   at System.Web.Mvc.JsonResult.ExecuteResult(ControllerContext context)&#xD;&#xA;   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)&#xD;&#xA;   at Castle.Proxies.AsyncControllerActionInvokerProxy.InvokeActionResult_callback(ControllerContext controllerContext, ActionResult actionResult)&#xD;&#xA;   at Castle.Proxies.Invocations.ControllerActionInvoker_InvokeActionResult.InvokeMethodOnTarget()&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Glimpse.Core.Extensibility.CastleInvocationToAlternateMethodContextAdapter.Proceed()&#xD;&#xA;   at Glimpse.Core.Extensibility.ExecutionTimer.Time(Action action)&#xD;&#xA;   at Glimpse.Core.Extensions.AlternateMethodContextExtensions.TryProceedWithTimer(IAlternateMethodContext context, TimerResult&amp; timerResult)&#xD;&#xA;   at Glimpse.Core.Extensibility.AlternateMethod.NewImplementation(IAlternateMethodContext context)&#xD;&#xA;   at Glimpse.Core.Extensibility.AlternateTypeToCastleInterceptorAdapter.Intercept(IInvocation invocation)&#xD;&#xA;   at Castle.DynamicProxy.AbstractInvocation.Proceed()&#xD;&#xA;   at Castle.Proxies.AsyncControllerActionInvokerProxy.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)&#xD;&#xA;   at System.Web.Mvc.ControllerActionInvoker.&lt;&gt;c__DisplayClass1a.&lt;InvokeActionResultWithFilters&gt;b__17()&#xD;&#xA;   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilter(IResultFilter filter, ResultExecutingContext preContext, Func`1 continuation)&#xD;&#xA;   at System.Web.Mvc.ControllerActionInvoker.&lt;&gt;c__DisplayClass1a.&lt;&gt;c__DisplayClass1c.&lt;InvokeActionResultWithFilters&gt;b__19()&#xD;&#xA;   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass25.&lt;&gt;c__DisplayClass2a.&lt;BeginInvokeAction&gt;b__20()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.&lt;&gt;c__DisplayClass25.&lt;BeginInvokeAction&gt;b__22(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.&lt;&gt;c__DisplayClass1d.&lt;BeginExecuteCore&gt;b__18(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.&lt;&gt;c__DisplayClass8.&lt;BeginProcessRequest&gt;b__3(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.&lt;&gt;c__DisplayClass4.&lt;MakeVoidDelegate&gt;b__3(IAsyncResult ar)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.Async.AsyncResultWrapper.End(IAsyncResult asyncResult, Object tag)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)&#xD;&#xA;   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()&#xD;&#xA;   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean&amp; completedSynchronously)"
  time="2014-04-10T15:33:29.9447511Z">
  <serverVariables>
    <item
      name="ALL_HTTP">
      <value
        string="HTTP_CONNECTION:keep-alive&#xD;&#xA;HTTP_CONTENT_LENGTH:13&#xD;&#xA;HTTP_CONTENT_TYPE:application/x-www-form-urlencoded; charset=UTF-8&#xD;&#xA;HTTP_ACCEPT:application/json, text/javascript, */*; q=0.01&#xD;&#xA;HTTP_ACCEPT_ENCODING:gzip,deflate,sdch&#xD;&#xA;HTTP_ACCEPT_LANGUAGE:en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;HTTP_COOKIE:glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=DcesC7SwWm8gtsTOxwdaEWMtGeEh5wYTvUjfOhFo79yrPtml06GGOQYL6mhe5IfqhUyYWhqDtMkdiLn-2MMmjDnfQAu0gzr0CPaKWRcjf-a3_ypCVWgnQALZif34nXRjsLimTA2; glimpseId=Chrome 33.0&#xD;&#xA;HTTP_HOST:localhost:26079&#xD;&#xA;HTTP_REFERER:http://localhost:26079/Admin/Product&#xD;&#xA;HTTP_USER_AGENT:Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;HTTP_GLIMPSE_PARENT_REQUESTID:5a2fb699-fdb3-4d8f-aab4-8dc83645da31&#xD;&#xA;HTTP_ORIGIN:http://localhost:26079&#xD;&#xA;HTTP_X_REQUESTED_WITH:XMLHttpRequest&#xD;&#xA;" />
    </item>
    <item
      name="ALL_RAW">
      <value
        string="Connection: keep-alive&#xD;&#xA;Content-Length: 13&#xD;&#xA;Content-Type: application/x-www-form-urlencoded; charset=UTF-8&#xD;&#xA;Accept: application/json, text/javascript, */*; q=0.01&#xD;&#xA;Accept-Encoding: gzip,deflate,sdch&#xD;&#xA;Accept-Language: en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2&#xD;&#xA;Cookie: glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=DcesC7SwWm8gtsTOxwdaEWMtGeEh5wYTvUjfOhFo79yrPtml06GGOQYL6mhe5IfqhUyYWhqDtMkdiLn-2MMmjDnfQAu0gzr0CPaKWRcjf-a3_ypCVWgnQALZif34nXRjsLimTA2; glimpseId=Chrome 33.0&#xD;&#xA;Host: localhost:26079&#xD;&#xA;Referer: http://localhost:26079/Admin/Product&#xD;&#xA;User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36&#xD;&#xA;Glimpse-Parent-RequestID: 5a2fb699-fdb3-4d8f-aab4-8dc83645da31&#xD;&#xA;Origin: http://localhost:26079&#xD;&#xA;X-Requested-With: XMLHttpRequest&#xD;&#xA;" />
    </item>
    <item
      name="APPL_MD_PATH">
      <value
        string="/LM/W3SVC/3/ROOT" />
    </item>
    <item
      name="APPL_PHYSICAL_PATH">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\" />
    </item>
    <item
      name="AUTH_TYPE">
      <value
        string="" />
    </item>
    <item
      name="AUTH_USER">
      <value
        string="" />
    </item>
    <item
      name="AUTH_PASSWORD">
      <value
        string="*****" />
    </item>
    <item
      name="LOGON_USER">
      <value
        string="" />
    </item>
    <item
      name="REMOTE_USER">
      <value
        string="" />
    </item>
    <item
      name="CERT_COOKIE">
      <value
        string="" />
    </item>
    <item
      name="CERT_FLAGS">
      <value
        string="" />
    </item>
    <item
      name="CERT_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERIALNUMBER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="CERT_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CERT_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="CONTENT_LENGTH">
      <value
        string="13" />
    </item>
    <item
      name="CONTENT_TYPE">
      <value
        string="application/x-www-form-urlencoded; charset=UTF-8" />
    </item>
    <item
      name="GATEWAY_INTERFACE">
      <value
        string="CGI/1.1" />
    </item>
    <item
      name="HTTPS">
      <value
        string="off" />
    </item>
    <item
      name="HTTPS_KEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SECRETKEYSIZE">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_ISSUER">
      <value
        string="" />
    </item>
    <item
      name="HTTPS_SERVER_SUBJECT">
      <value
        string="" />
    </item>
    <item
      name="INSTANCE_ID">
      <value
        string="3" />
    </item>
    <item
      name="INSTANCE_META_PATH">
      <value
        string="/LM/W3SVC/3" />
    </item>
    <item
      name="LOCAL_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="PATH_INFO">
      <value
        string="/Admin/Product/ProductListWithPaging" />
    </item>
    <item
      name="PATH_TRANSLATED">
      <value
        string="C:\GITREPOSITORY\GITHUB\SHOPPE\Exchange.Web\Admin\Product\ProductListWithPaging" />
    </item>
    <item
      name="QUERY_STRING">
      <value
        string="jtStartIndex=1&amp;jtPageSize=15" />
    </item>
    <item
      name="REMOTE_ADDR">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_HOST">
      <value
        string="::1" />
    </item>
    <item
      name="REMOTE_PORT">
      <value
        string="6244" />
    </item>
    <item
      name="REQUEST_METHOD">
      <value
        string="POST" />
    </item>
    <item
      name="SCRIPT_NAME">
      <value
        string="/Admin/Product/ProductListWithPaging" />
    </item>
    <item
      name="SERVER_NAME">
      <value
        string="localhost" />
    </item>
    <item
      name="SERVER_PORT">
      <value
        string="26079" />
    </item>
    <item
      name="SERVER_PORT_SECURE">
      <value
        string="0" />
    </item>
    <item
      name="SERVER_PROTOCOL">
      <value
        string="HTTP/1.1" />
    </item>
    <item
      name="SERVER_SOFTWARE">
      <value
        string="Microsoft-IIS/8.0" />
    </item>
    <item
      name="URL">
      <value
        string="/Admin/Product/ProductListWithPaging" />
    </item>
    <item
      name="HTTP_CONNECTION">
      <value
        string="keep-alive" />
    </item>
    <item
      name="HTTP_CONTENT_LENGTH">
      <value
        string="13" />
    </item>
    <item
      name="HTTP_CONTENT_TYPE">
      <value
        string="application/x-www-form-urlencoded; charset=UTF-8" />
    </item>
    <item
      name="HTTP_ACCEPT">
      <value
        string="application/json, text/javascript, */*; q=0.01" />
    </item>
    <item
      name="HTTP_ACCEPT_ENCODING">
      <value
        string="gzip,deflate,sdch" />
    </item>
    <item
      name="HTTP_ACCEPT_LANGUAGE">
      <value
        string="en-GB,en;q=0.8,en-US;q=0.6,es;q=0.4,fil;q=0.2,it;q=0.2" />
    </item>
    <item
      name="HTTP_COOKIE">
      <value
        string="glimpsePolicy=On; glimpseOptions=%7B%22glimpsePolicy%22%3Anull%7D; __RequestVerificationToken=DcesC7SwWm8gtsTOxwdaEWMtGeEh5wYTvUjfOhFo79yrPtml06GGOQYL6mhe5IfqhUyYWhqDtMkdiLn-2MMmjDnfQAu0gzr0CPaKWRcjf-a3_ypCVWgnQALZif34nXRjsLimTA2; glimpseId=Chrome 33.0" />
    </item>
    <item
      name="HTTP_HOST">
      <value
        string="localhost:26079" />
    </item>
    <item
      name="HTTP_REFERER">
      <value
        string="http://localhost:26079/Admin/Product" />
    </item>
    <item
      name="HTTP_USER_AGENT">
      <value
        string="Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36" />
    </item>
    <item
      name="HTTP_GLIMPSE_PARENT_REQUESTID">
      <value
        string="5a2fb699-fdb3-4d8f-aab4-8dc83645da31" />
    </item>
    <item
      name="HTTP_ORIGIN">
      <value
        string="http://localhost:26079" />
    </item>
    <item
      name="HTTP_X_REQUESTED_WITH">
      <value
        string="XMLHttpRequest" />
    </item>
  </serverVariables>
  <queryString>
    <item
      name="jtStartIndex">
      <value
        string="1" />
    </item>
    <item
      name="jtPageSize">
      <value
        string="15" />
    </item>
  </queryString>
  <form>
    <item
      name="searchString">
      <value
        string="" />
    </item>
  </form>
  <cookies>
    <item
      name="glimpsePolicy">
      <value
        string="On" />
    </item>
    <item
      name="glimpseOptions">
      <value
        string="%7B%22glimpsePolicy%22%3Anull%7D" />
    </item>
    <item
      name="__RequestVerificationToken">
      <value
        string="DcesC7SwWm8gtsTOxwdaEWMtGeEh5wYTvUjfOhFo79yrPtml06GGOQYL6mhe5IfqhUyYWhqDtMkdiLn-2MMmjDnfQAu0gzr0CPaKWRcjf-a3_ypCVWgnQALZif34nXRjsLimTA2" />
    </item>
    <item
      name="glimpseId">
      <value
        string="Chrome 33.0" />
    </item>
  </cookies>
</error>')
SET IDENTITY_INSERT [dbo].[ELMAH_Error] OFF
/****** Object:  Table [dbo].[Customer]    Script Date: 04/20/2014 10:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [uniqueidentifier] NOT NULL,
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
 CONSTRAINT [PK_Customer_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersInStore]    Script Date: 04/20/2014 10:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInStore](
	[Users_Id] [uniqueidentifier] NOT NULL,
	[Store_Id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersInRoles]    Script Date: 04/20/2014 10:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInRoles](
	[Users_Id] [uniqueidentifier] NOT NULL,
	[Roles_Id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 04/20/2014 10:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [uniqueidentifier] NOT NULL,
	[InvoiceNo] [nvarchar](50) NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[TotalBonus] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[Cashier_Id] [uniqueidentifier] NULL,
	[Appraiser_Id] [uniqueidentifier] NULL,
	[Customer_Id] [uniqueidentifier] NULL,
	[Store_Id] [uniqueidentifier] NULL,
	[Status_Id] [uniqueidentifier] NULL,
	[DateIssued] [datetime] NULL,
	[DateModified] [datetime] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_LogError]    Script Date: 04/20/2014 10:22:07 ******/
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
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorXml]    Script Date: 04/20/2014 10:22:07 ******/
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
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorsXml]    Script Date: 04/20/2014 10:22:07 ******/
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
/****** Object:  Table [dbo].[CashOnHand]    Script Date: 04/20/2014 10:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashOnHand](
	[Id] [uniqueidentifier] NOT NULL,
	[Store_id] [uniqueidentifier] NULL,
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
/****** Object:  Table [dbo].[Product]    Script Date: 04/20/2014 10:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [uniqueidentifier] NOT NULL,
	[ProductType_Id] [uniqueidentifier] NULL,
	[Code] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[Cost] [decimal](18, 2) NULL,
	[Active] [bit] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_Product_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Product] ([Id], [ProductType_Id], [Code], [Name], [Description], [Cost], [Active], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (N'c740c2ee-9152-4771-9ad1-760efce6a876', NULL, N'1002', N'Gold2', N'Gold', CAST(34.56 AS Decimal(18, 2)), 1, N'jfvaleroso', CAST(0x0000A3060180E340 AS DateTime), NULL, NULL)
INSERT [dbo].[Product] ([Id], [ProductType_Id], [Code], [Name], [Description], [Cost], [Active], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (N'ef6a994f-8cc0-40bd-8a2b-a3060180e40c', N'11b19ff1-90ec-498c-8f52-a3060180cb35', N'1001', N'Gold', N'Gold', CAST(34.56 AS Decimal(18, 2)), 1, N'jfvaleroso', CAST(0x0000A3060180E340 AS DateTime), NULL, NULL)
INSERT [dbo].[Product] ([Id], [ProductType_Id], [Code], [Name], [Description], [Cost], [Active], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified]) VALUES (N'28742f28-945d-4d9f-bd0c-f4d4d81223f5', NULL, N'103', N'Gold3', N'Gold', CAST(34.56 AS Decimal(18, 2)), 1, N'jfvaleroso', CAST(0x0000A3060180E340 AS DateTime), NULL, NULL)
/****** Object:  Table [dbo].[Profiles]    Script Date: 04/20/2014 10:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Profiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Users_Id] [uniqueidentifier] NOT NULL,
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
/****** Object:  Table [dbo].[Purchase]    Script Date: 04/20/2014 10:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[Id] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NULL,
	[Grams] [decimal](18, 2) NULL,
	[Rate] [decimal](18, 2) NULL,
	[Cost] [decimal](18, 2) NULL,
	[Bonus] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[Description] [nvarchar](200) NULL,
	[Invoice_Id] [uniqueidentifier] NULL,
	[Product_Id] [uniqueidentifier] NULL,
	[SecurityCode_Id] [uniqueidentifier] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_Purchase_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductHistory]    Script Date: 04/20/2014 10:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductHistory](
	[Id] [uniqueidentifier] NOT NULL,
	[Product_Id] [uniqueidentifier] NULL,
	[Cost] [decimal](18, 2) NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_ProductHistory_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Note]    Script Date: 04/20/2014 10:22:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Note](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
	[Invoice_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Note_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Store_Id]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[Store] ADD  CONSTRAINT [DF_Store_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_Status_Id]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[Status] ADD  CONSTRAINT [DF_Status_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_SecurityCode_Id]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[SecurityCode] ADD  CONSTRAINT [DF_SecurityCode_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_Roles_Id]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_ELMAH_Error_ErrorId]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[ELMAH_Error] ADD  CONSTRAINT [DF_ELMAH_Error_ErrorId]  DEFAULT (newid()) FOR [ErrorId]
GO
/****** Object:  Default [DF_Customer_Id2]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Id2]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_Invoice_Id]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_CashOnHand_Id]    Script Date: 04/20/2014 10:22:07 ******/
ALTER TABLE [dbo].[CashOnHand] ADD  CONSTRAINT [DF_CashOnHand_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_Product_Id]    Script Date: 04/20/2014 10:22:07 ******/
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_Purchase_Id]    Script Date: 04/20/2014 10:22:07 ******/
ALTER TABLE [dbo].[Purchase] ADD  CONSTRAINT [DF_Purchase_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_ProductHistory_Id]    Script Date: 04/20/2014 10:22:07 ******/
ALTER TABLE [dbo].[ProductHistory] ADD  CONSTRAINT [DF_ProductHistory_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_Note_Ids]    Script Date: 04/20/2014 10:22:07 ******/
ALTER TABLE [dbo].[Note] ADD  CONSTRAINT [DF_Note_Ids]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  ForeignKey [FK_UsersInStore_Store]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[UsersInStore]  WITH CHECK ADD  CONSTRAINT [FK_UsersInStore_Store] FOREIGN KEY([Store_Id])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[UsersInStore] CHECK CONSTRAINT [FK_UsersInStore_Store]
GO
/****** Object:  ForeignKey [FK_UsersInStore_Users]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[UsersInStore]  WITH CHECK ADD  CONSTRAINT [FK_UsersInStore_Users] FOREIGN KEY([Users_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UsersInStore] CHECK CONSTRAINT [FK_UsersInStore_Users]
GO
/****** Object:  ForeignKey [FK_UsersInRoles_Roles]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRoles_Roles] FOREIGN KEY([Roles_Id])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [FK_UsersInRoles_Roles]
GO
/****** Object:  ForeignKey [FK_UsersInRoles_Users]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRoles_Users] FOREIGN KEY([Users_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [FK_UsersInRoles_Users]
GO
/****** Object:  ForeignKey [FK_Invoice_Appraiser]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Appraiser] FOREIGN KEY([Appraiser_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Appraiser]
GO
/****** Object:  ForeignKey [FK_Invoice_Cashier]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Cashier] FOREIGN KEY([Cashier_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Cashier]
GO
/****** Object:  ForeignKey [FK_Invoice_Customer]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Customer] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Customer]
GO
/****** Object:  ForeignKey [FK_Invoice_Status]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Status] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Status]
GO
/****** Object:  ForeignKey [FK_Invoice_Store]    Script Date: 04/20/2014 10:22:03 ******/
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Store] FOREIGN KEY([Store_Id])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Store]
GO
/****** Object:  ForeignKey [FK_CashOnHand_Store]    Script Date: 04/20/2014 10:22:07 ******/
ALTER TABLE [dbo].[CashOnHand]  WITH CHECK ADD  CONSTRAINT [FK_CashOnHand_Store] FOREIGN KEY([Store_id])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[CashOnHand] CHECK CONSTRAINT [FK_CashOnHand_Store]
GO
/****** Object:  ForeignKey [FK_Product_ProductType]    Script Date: 04/20/2014 10:22:07 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([ProductType_Id])
REFERENCES [dbo].[ProductType] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
/****** Object:  ForeignKey [FK_Profiles_Users]    Script Date: 04/20/2014 10:22:07 ******/
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [FK_Profiles_Users] FOREIGN KEY([Users_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [FK_Profiles_Users]
GO
/****** Object:  ForeignKey [FK_Purchase_Invoice]    Script Date: 04/20/2014 10:22:07 ******/
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Invoice] FOREIGN KEY([Invoice_Id])
REFERENCES [dbo].[Invoice] ([Id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Invoice]
GO
/****** Object:  ForeignKey [FK_Purchase_Product]    Script Date: 04/20/2014 10:22:07 ******/
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Product] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Product]
GO
/****** Object:  ForeignKey [FK_Purchase_SecurityCode]    Script Date: 04/20/2014 10:22:07 ******/
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_SecurityCode] FOREIGN KEY([SecurityCode_Id])
REFERENCES [dbo].[SecurityCode] ([Id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_SecurityCode]
GO
/****** Object:  ForeignKey [FK_ProductHistory_Product]    Script Date: 04/20/2014 10:22:07 ******/
ALTER TABLE [dbo].[ProductHistory]  WITH CHECK ADD  CONSTRAINT [FK_ProductHistory_Product] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductHistory] CHECK CONSTRAINT [FK_ProductHistory_Product]
GO
/****** Object:  ForeignKey [FK_Note_Invoice]    Script Date: 04/20/2014 10:22:07 ******/
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Invoice] FOREIGN KEY([Invoice_Id])
REFERENCES [dbo].[Invoice] ([Id])
GO
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Invoice]
GO
