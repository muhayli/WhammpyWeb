using System;
namespace Whammy.Utility
{
    public static class SD
    {
        public const string ManagerRole = "Manager";
        public const string FrontDeskRole = "Front";
        public const string kitchenRole = "Kitchen";
        public const string CustomerRole = "Customer";


        public const string StatusPending = "PENDING_PAYMENT";
        public const string StatusSubmitted = "SUBMITTED_PAYMENTAPPROVED";
        public const string StatusRejected = "REJECTED_PAYMENT";
        public const string StatusInProgress = "BEING PREPARED";
        public const string StatusReady = "READY FOR PICKUP";
        public const string StatusCompleted = "COMPLETED";
        public const string StatusCancelled = "CANCELLED";
        public const string StatusRefunded = "REFUNDED";
    }
}

