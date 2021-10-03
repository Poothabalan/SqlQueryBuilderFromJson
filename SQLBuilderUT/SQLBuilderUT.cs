using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SqlServer.Management.SqlParser.Parser;
using SQLQueryBuilder;
using SQLQueryBuilder.Interfaces;
using SQLQueryBuilder.Implementations;
using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLQueryBuilder.Common;

namespace SQLBuilderUT
{
    [TestClass]
    public class SelectTest
    {
      

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CheckNullInputForBuildQuery()
        {
            //Arrange
            StatementModel statementModel=null;
            IOperation operation = new Select();
            //Act
            operation.BuildQuery(statementModel);
            //Assert
        }
        [TestMethod]
       public void ValidateParsedStringWithoutConditionalClause()
        {
            //Arrange
            StatementModel statementModel = null;
            IOperation operation = new Select();
            var jsonString = File.ReadAllText(@"JsonInputs\WithoutConditionalClause.json");
            statementModel = Common.GetCommandObjectModel(jsonString);
            //Act
            string statement = operation.BuildQuery(statementModel);
            var result = Parser.Parse(statement);
            Assert.AreEqual(0, result.Errors.Count());
              
        }
        [TestMethod]
        public void ValidateParsedStringWithSingleConditionalClauseINAnd()
        {
            //Arrange
            StatementModel statementModel = null;
            IOperation operation = new Select();
            var jsonString = File.ReadAllText(@"JsonInputs\WithSingleConditionalClauseINAnd.json");
            statementModel = Common.GetCommandObjectModel(jsonString);
            //Act
            string statement = operation.BuildQuery(statementModel);
            var result = Parser.Parse(statement);
            Assert.AreEqual(0, result.Errors.Count());

        }
        [TestMethod]
        public void ValidateParsedStringWithSingleConditionalClauseINOR()
        {
            //Arrange
            StatementModel statementModel = null;
            IOperation operation = new Select();
            var jsonString = File.ReadAllText(@"JsonInputs\WithSingleConditionalClauseINOR.json");
            statementModel = Common.GetCommandObjectModel(jsonString);
            //Act
            string statement = operation.BuildQuery(statementModel);
            var result = Parser.Parse(statement);
            Assert.AreEqual(0, result.Errors.Count());

        }

        [TestMethod]
        public void ValidateParsedStringWithTwoConditionalClauseINAND()
        {
            //Arrange
            StatementModel statementModel = null;
            IOperation operation = new Select();
            var jsonString = File.ReadAllText(@"JsonInputs\WithTwoConditionalClauseINAnd.json");
            statementModel = Common.GetCommandObjectModel(jsonString);
            //Act
            string statement = operation.BuildQuery(statementModel);
            var result = Parser.Parse(statement);
            Assert.AreEqual(0, result.Errors.Count());

        }

        [TestMethod]
        public void ValidateParsedStringWithTwoConditionalClauseINOR()
        {
            //Arrange
            StatementModel statementModel = null;
            IOperation operation = new Select();
            var jsonString = File.ReadAllText(@"JsonInputs\WithTwoConditionalClauseINOR.json");
            statementModel = Common.GetCommandObjectModel(jsonString);
            //Act
            string statement = operation.BuildQuery(statementModel);
            var result = Parser.Parse(statement);
            Assert.AreEqual(0, result.Errors.Count());

        }

        [TestMethod]
        public void ValidateParsedStringWithConditionalClauseINBothAndOR()
        {
            //Arrange
            StatementModel statementModel = null;
            IOperation operation = new Select();
            var jsonString = File.ReadAllText(@"JsonInputs\WithConditionalClauseINBothAndOR.json");
            statementModel = Common.GetCommandObjectModel(jsonString);
            //Act
            string statement = operation.BuildQuery(statementModel);
            var result = Parser.Parse(statement);
            Assert.AreEqual(0, result.Errors.Count());

        }

        [TestMethod]
        public void ValidateSubQuerySingleConditionalClauseInEqualOperator()
        {
            //Arrange
            StatementModel statementModel = new StatementModel();
            IOperation operation = new Select();
            var jsonString = File.ReadAllText(@"JsonInputs\SubQuerySingleConditionalClauseInEqualOperator.json");
            statementModel = Common.GetCommandObjectModel(jsonString);
            //Act
            string statement = operation.BuildQuery(statementModel);
            var result = Parser.Parse(statement);
            Assert.AreEqual(0, result.Errors.Count());
            
        }

        [TestMethod]
        public void SubQueryTwoConditionalClauseInEqualOperator()
        {
            //Arrange
            StatementModel statementModel = new StatementModel();
            IOperation operation = new Select();
            var jsonString = File.ReadAllText(@"JsonInputs\SubQueryTwoConditionalClauseInEqualOperator.json");
            statementModel = Common.GetCommandObjectModel(jsonString);
            //Act
            string statement = operation.BuildQuery(statementModel);
            var result = Parser.Parse(statement);
            Assert.AreEqual(0, result.Errors.Count());

        }
        [TestMethod]
        public void SubQueryTwoConditionalClauseWithINOperator()
        {
            //Arrange
            StatementModel statementModel = new StatementModel();
            IOperation operation = new Select();
            var jsonString = File.ReadAllText(@"JsonInputs\SubQueryTwoConditionalClauseWithINOperator.json");
            statementModel = Common.GetCommandObjectModel(jsonString);
            //Act
            string statement = operation.BuildQuery(statementModel);
            var result = Parser.Parse(statement);
            Assert.AreEqual(0, result.Errors.Count());

        }
        [TestMethod]
        public void ValidateREcursiveSubQuery()
        {
            //Arrange
            StatementModel statementModel = new StatementModel();
            IOperation operation = new Select();
            var jsonString = File.ReadAllText(@"JsonInputs\RecursiveSubQuery.json");
            statementModel = Common.GetCommandObjectModel(jsonString);
            //Act
            string statement = operation.BuildQuery(statementModel);
            var result = Parser.Parse(statement);
            Assert.AreEqual(0, result.Errors.Count());

        }
        [TestMethod]
        public void ValidateBetweenOperator()
        {
            //Arrange
            StatementModel statementModel = new StatementModel();
            IOperation operation = new Select();
            var jsonString = File.ReadAllText(@"JsonInputs\WithSingleConditionalClauseIWithBetweenOperator.json");
            statementModel = Common.GetCommandObjectModel(jsonString);
            //Act
            string statement = operation.BuildQuery(statementModel);
            var result = Parser.Parse(statement);
            Assert.AreEqual(0, result.Errors.Count());

        }
        [TestMethod]
        public void ValidateINOperatorWithArray()
        {
            //Arrange
            StatementModel statementModel = new StatementModel();
            IOperation operation = new Select();
            var jsonString = File.ReadAllText(@"JsonInputs\INOperatorWithArrayOfValues.json");
            statementModel = Common.GetCommandObjectModel(jsonString);
            //Act
            string statement = operation.BuildQuery(statementModel);
            var result = Parser.Parse(statement);
            Assert.AreEqual(0, result.Errors.Count());

        }
       
    }
}
