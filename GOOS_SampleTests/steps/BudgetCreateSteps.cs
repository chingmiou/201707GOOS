﻿using FluentAutomation;
using GOOS_SampleTests.PageObjects;
using System;
using GOOS_Sample.Models.DataModels;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GOOS_SampleTests.steps
{
    [Binding]
    [Scope(Feature = "BudgetCreate")]
    public class BudgetCreateSteps : FluentTest
    {
        private BudgetCreatePage _budgetCreatePage;
        
        public BudgetCreateSteps()
        {
            this._budgetCreatePage = new BudgetCreatePage(this);
        }

        [Given(@"go to adding budget page")]
        public void GivenGoToAddingBudgetPage()
        {
            this._budgetCreatePage.Go();
        }

        [When(@"I add a buget (.*) for ""(.*)""")]
        public void WhenIAddABugetFor(int amount, string yearMonth)
        {
            this._budgetCreatePage
                .Amount(amount)
                .Month(yearMonth)
                .AddBudget();
        }
        
        [Then(@"it should display ""(.*)""")]
        public void ThenItShouldDisplay(string message)
        {
            this._budgetCreatePage.ShouldDisplay(message);
        }


        [Given(@"Budget table existed budgets")]
        public void GivenBudgetTableExistedBudgets(Table table)
        {
            var budgets = table.CreateSet<Budget>();
            using (var dbcontext = new GOOS_Sample.Models.DataModels.Aluxe_TestEntities())
            {
                dbcontext.Budgets.AddRange(budgets);
                dbcontext.SaveChanges();
            }
        }

    }
    
}
