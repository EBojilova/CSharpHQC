﻿namespace ChainOfResponsibility
{
    using System;

    using ChainOfResponsibility.Approvers;

    internal class ChainOfResponsibilityMain
    {
        internal static void Main()
        {
            Approver teamLead = new TeamLead();
            Approver vicePresident = new VicePresident();
            Approver president = new President();

            teamLead.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            var purchase = new Purchase(2034, 350.00);
            teamLead.ProcessRequest(purchase);

            purchase = new Purchase(2035, 32590.10);
            teamLead.ProcessRequest(purchase);

            purchase = new Purchase(2036, 122100.00);
            teamLead.ProcessRequest(purchase);
        }
    }
}