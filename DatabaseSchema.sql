USE [TeamSurveyApp]
GO
/****** Object:  UserDefinedTableType [dbo].[Questions]    Script Date: 8/01/2021 1:11:52 p. m. ******/
CREATE TYPE [dbo].[Questions] AS TABLE(
	[Question_Id] [int] NULL
)
GO
/****** Object:  Table [dbo].[Question]    Script Date: 8/01/2021 1:11:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [varchar](200) NOT NULL,
	[Updated] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question_Order]    Script Date: 8/01/2021 1:11:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_Order](
	[Question_Id] [int] NOT NULL,
	[Survey_Id] [int] NOT NULL,
	[Order] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Survey_Id] ASC,
	[Question_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respondent]    Script Date: 8/01/2021 1:11:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respondent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[HashedPassword] [varchar](100) NOT NULL,
	[Email] [varchar](254) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Response]    Script Date: 8/01/2021 1:11:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Response](
	[Survey_Response_Id] [int] NOT NULL,
	[Question_Id] [int] NOT NULL,
	[Respondent_Id] [int] NOT NULL,
	[Answer] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Survey_Response_Id] ASC,
	[Question_Id] ASC,
	[Respondent_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 8/01/2021 1:11:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survey](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](1000) NULL,
	[Updated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Survey] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey_Response]    Script Date: 8/01/2021 1:11:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survey_Response](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Survey_Id] [int] NOT NULL,
	[Respondent_Id] [int] NOT NULL,
	[Updated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Survey_Response] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Question] ADD  DEFAULT (getdate()) FOR [Updated]
GO
ALTER TABLE [dbo].[Respondent] ADD  DEFAULT (getdate()) FOR [Created]
GO
ALTER TABLE [dbo].[Survey] ADD  DEFAULT (getdate()) FOR [Updated]
GO
ALTER TABLE [dbo].[Survey_Response] ADD  DEFAULT (getdate()) FOR [Updated]
GO
ALTER TABLE [dbo].[Question_Order]  WITH CHECK ADD  CONSTRAINT [FK_Question_Order_ToQuestion] FOREIGN KEY([Question_Id])
REFERENCES [dbo].[Question] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Question_Order] CHECK CONSTRAINT [FK_Question_Order_ToQuestion]
GO
ALTER TABLE [dbo].[Question_Order]  WITH CHECK ADD  CONSTRAINT [FK_Question_Order_ToSurvey] FOREIGN KEY([Survey_Id])
REFERENCES [dbo].[Survey] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Question_Order] CHECK CONSTRAINT [FK_Question_Order_ToSurvey]
GO
ALTER TABLE [dbo].[Response]  WITH CHECK ADD  CONSTRAINT [FK_Response_ToQuestion] FOREIGN KEY([Question_Id])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[Response] CHECK CONSTRAINT [FK_Response_ToQuestion]
GO
ALTER TABLE [dbo].[Response]  WITH CHECK ADD  CONSTRAINT [FK_Response_ToRespondent] FOREIGN KEY([Respondent_Id])
REFERENCES [dbo].[Respondent] ([Id])
GO
ALTER TABLE [dbo].[Response] CHECK CONSTRAINT [FK_Response_ToRespondent]
GO
ALTER TABLE [dbo].[Response]  WITH CHECK ADD  CONSTRAINT [FK_Response_ToSurvey_Response] FOREIGN KEY([Survey_Response_Id])
REFERENCES [dbo].[Survey_Response] ([Id])
GO
ALTER TABLE [dbo].[Response] CHECK CONSTRAINT [FK_Response_ToSurvey_Response]
GO
ALTER TABLE [dbo].[Survey_Response]  WITH CHECK ADD  CONSTRAINT [FK_Survey_Response_ToRespondent] FOREIGN KEY([Respondent_Id])
REFERENCES [dbo].[Respondent] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Survey_Response] CHECK CONSTRAINT [FK_Survey_Response_ToRespondent]
GO
ALTER TABLE [dbo].[Survey_Response]  WITH CHECK ADD  CONSTRAINT [FK_Survey_Response_ToSurvey] FOREIGN KEY([Survey_Id])
REFERENCES [dbo].[Survey] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Survey_Response] CHECK CONSTRAINT [FK_Survey_Response_ToSurvey]
GO
/****** Object:  StoredProcedure [dbo].[Survey_Update]    Script Date: 8/01/2021 1:11:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Survey_Update]
	@SurveyId int,
	@SurveyName varchar(50),
    @SurveyDescription varchar(1000) NULL,
    @QuestionIds Questions READONLY
AS

    BEGIN TRANSACTION;

    -- Update the Survey info.
	UPDATE Survey SET 
        Name = @SurveyName,
        Description = @SurveyDescription,
        Updated = GETDATE()
    WHERE Id = @SurveyId;

    -- Remove the Questions that are no longer part of the survey.
    DELETE FROM Question_Order
    WHERE Question_Order.Survey_Id = @SurveyId 
        AND Question_Order.Question_Id NOT IN (SELECT Question_Id FROM @QuestionIds);

    -- Insert or update the questions belonging to this survey.
    MERGE INTO Question_Order AS Target
    USING (
        SELECT 
            Question_Id, 
            @SurveyId AS Survey_Id, 
            ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS [Order] 
        FROM @QuestionIds
    ) AS Source
    ON Target.Question_Id = Source.Question_Id AND Target.Survey_Id = Source.Survey_Id
    WHEN MATCHED THEN
        -- If it already exists, just update the order.
        UPDATE SET [Order] = Source.[Order]
    WHEN NOT MATCHED BY Target THEN
        -- If it doesn't exist, insert it.
        INSERT (Question_Id, Survey_Id, [Order]) VALUES (Source.Question_Id, Source.Survey_Id, Source.[Order]);

    COMMIT;

RETURN 0
GO
