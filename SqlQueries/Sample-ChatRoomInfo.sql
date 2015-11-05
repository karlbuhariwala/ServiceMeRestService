INSERT INTO
    [ChatRoomInfo]
    (
        CaseId
        , ChatId
        , ParticipantsAgents
        , ParticipantsUsers
        , Deleted
        , [DateTimeCreated]
        , [DateTimeUpdated]
    )
VALUES
    (
        '8d126288-81bd-4ee4-bf61-0930ceb551c6'
        , '8d126288-81bd-4ee4-bf61-0930ceb551c6'
        , 'Tes12'
        , 'Tes34'
        , 0
        , CURRENT_TIMESTAMP
        , CURRENT_TIMESTAMP
    )

-- Select top 10
SELECT 
    TOP 10
    *
FROM
    [ChatRoomInfo]
ORDER BY
    Id desc

DELETE FROM [ChatRoomInfo]
WHERE Id = 1 
