CREATE TABLE CandidateSkills (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CandidateId INT NOT NULL,
    SkillName NVARCHAR(100) NOT NULL,
    ExperienceYears INT NOT NULL
);