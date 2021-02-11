﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Core
{
    public static class Validator
    {
        public static void ValidateParameters(IList<string> parameters,int n)
        {
            if (parameters.Count != n)
            {
                throw new ArgumentException("Parameters count is not valid");
            }
        }
        public static void ValidateParamsIfLessThan(IList<string> parameters, int n)
        {
            if (parameters.Count < n)
            {
                throw new ArgumentException("Parameters count is not valid");
            }
        }
        public static void TeamExists(string name)
        {
            bool teamExists = Database.Instance.AllTeams.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (teamExists)
            {
                throw new ArgumentException($"Team: '{name}' already exists");
            }
        } 
        public static void MemberExists(string name)
        {
            bool nameExists = Database.Instance.AllMembers.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (nameExists)
            {
                throw new ArgumentException($"Member: '{name}' already exists.");
            }
        }
        public static void MemberExistsInTeam(string name,ITeam team)
        {
            bool memberExistsInTeam = team.Members.Any(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (memberExistsInTeam)
            {
                throw new ArgumentException($"Member: '{name}' already exist in team: '{team.Name}'.");
            }
        }
        public static void MemberExistsInAnyTeam(string name)
        {
            var isInAnyTeam = Database.Instance.AllTeams
                               .SelectMany(t => t.Members)
                               .Any(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (!isInAnyTeam)
            {
                throw new ArgumentException($"Member: '{name}' is not in any team.");
            }
        }

        public static void BoardExistsInTeam(string name,ITeam team)
        {
            var boardExists = team.Boards.Any(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (boardExists)
            {
                throw new ArgumentException($"Board: '{name}' already exists in team: '{team.Name}'");
            }
        }
        public static ITeam GetTeam(string name)
        {
            var team = Database.Instance.AllTeams.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (team == null)
            {
                throw new ArgumentException($"Team: '{name}' does not exist.");
            }
            return team;
        }
        public static IBoard GetBoard(string name,ITeam team)
        {
            var existingBoard = team.Boards.FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existingBoard == null)
            {
                throw new ArgumentException($"Board: '{name}' does not exist in team:'{team.Name}'.");
            }
            return existingBoard;
        }
        public static IMember GetMember(string name)
        {
            var member = Database.Instance.AllMembers.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (member == null)
            {
                throw new ArgumentException($"Member: '{name}' does not exist.");
            }
            return member;
        }

        public static IWorkItemsAssignee GetWorkItemToAssign(string id)
        {
            var workItem = (IWorkItemsAssignee)Database.Instance.AllWorkItems.FirstOrDefault(item => item.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (workItem == null)
            {
                throw new ArgumentException($"Work item: '{id}' does not exist.");
            }
            return workItem;
        }

        public static IWorkItem GetWorkItem(string id)
        {
            var workItem = Database.Instance.AllWorkItems.FirstOrDefault(item => item.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (workItem == null)
            {
                throw new ArgumentException($"Work item: '{id}' does not exist.");
            }
            return workItem;
        }

        public static IList<IWorkItem> GetAllWorkItems()
        {
            return Database.Instance.AllWorkItems;
        }
        public static IList<ITeam> GetAllTeams()
        {
            return Database.Instance.AllTeams;
        }
        public static IList<IMember> GetAllMembers()
        {
            return Database.Instance.AllMembers;
        }
    }
}