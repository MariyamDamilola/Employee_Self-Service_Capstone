namespace Employee_Self_Service_Capstone.Domain.Enum;

public enum TrainingRequestStatus
{
    Draft = 1,
    PendingManagerApproval = 2,
    PendingHRApproval = 3,
    PendingFinanceApproval = 4,
    ReturnedToHR = 5,
    Approved = 6,
    Completed = 7,
    Rejected = 8,
    Withdrawn = 9,
    RejectedNoEvidence = 10
}