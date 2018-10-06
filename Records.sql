CREATE TABLE [dbo].[ViewMemo] (
    [id]              INT           IDENTITY (1, 1) NOT NULL,
    [answerQuestion1] VARCHAR (255) NOT NULL,
    [answerQuestion2] VARCHAR (255) NOT NULL,
    [answerQuestion3] VARCHAR (255) NOT NULL,
    [answerQuestion4] VARCHAR (255) NOT NULL,
    [answerQuestion5] VARCHAR (255) NOT NULL
);



CREATE TABLE [dbo].[StudentAnswers] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [studentAnswer1] VARCHAR (255) NOT NULL,
    [studentAnswer2] VARCHAR (255) NOT NULL,
    [studentAnswer3] VARCHAR (255) NOT NULL,
    [studentAnswer4] VARCHAR (255) NOT NULL,
    [studentAnswer5] VARCHAR (255) NOT NULL
);


CREATE TABLE [dbo].[LectureQuestions] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [question1] VARCHAR (255) NOT NULL,
    [question2] VARCHAR (255) NOT NULL,
    [question3] VARCHAR (255) NOT NULL,
    [question4] VARCHAR (255) NOT NULL,
    [question5] VARCHAR (255) NOT NULL
);

