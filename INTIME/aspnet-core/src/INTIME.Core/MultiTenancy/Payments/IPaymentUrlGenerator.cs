﻿namespace INTIME.MultiTenancy.Payments
{
    public interface IPaymentUrlGenerator
    {
        string CreatePaymentRequestUrl(SubscriptionPayment subscriptionPayment);
    }
}