using System;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Abstract;

namespace WorkItemManagement.Models.WorkItems
{
    public class Story : WorkItem, IStory
    {
        private IMember assignee;
        private PriorityType priorityType;
        private StoryStatusType storyStatus;
        private SizeType sizeType;
        public Story(string id,string title, PriorityType priority, SizeType size, string description)
            : base(id, title, description)
        {
            this.priorityType = priority;
            this.storyStatus = StoryStatusType.NotDone;
            this.sizeType = size;
        }

        public PriorityType Priority 
        {
            get => this.priorityType;
            private set
            {
                this.AddHistory($"Story priority type changed from '{this.priorityType}' to '{value}'.");
                this.priorityType = value;
            }
        }

        public StoryStatusType StoryStatus 
        {
            get => this.storyStatus;
            private set
            {
                this.AddHistory($"Story status type changed from '{this.storyStatus}' to '{value}'.");
                this.storyStatus = value;
            }
        }
        public SizeType Size
        {
            get => this.sizeType;
            private set
            {
                this.AddHistory($"Story size changed from '{this.sizeType}' to '{value}'.");
                this.sizeType = value;
            }
        }
        public IMember Assignee
        {
            get => this.assignee;
            private set
            {
                if (this.assignee == null)
                {
                    this.AddHistory($"Story assigned to '{value.Name}'.");
                }
                else
                {
                    if (value == null)
                    {
                        this.AddHistory($"Story assignee removed.");
                    }
                    else
                    {
                        this.AddHistory($"Story assignee changed from '{this.assignee.Name}' to '{value.Name}'.");
                    }
                }
                this.assignee = value;
            }
        }

        /// <summary>
        /// Add assignee if it doesn't have one
        /// </summary>
        /// <param name="member">Assignee to be added</param>
        public void AddAssignee(IMember member)
        {
            if (this.Assignee == member)
            {
                throw new ArgumentException($"Story already assigned to '{member.Name}'");
            }
            this.Assignee = member;
        }

        /// <summary>
        /// Remove assignee if it already has one
        /// </summary>
        public void RemoveAssignee()
        {
            if (this.Assignee == null)
            {
                throw new ArgumentException($"Story has no assignee.");
            }
            this.Assignee = null;
        }

        /// <summary>
        /// Gets the assignee of a work item
        /// </summary>
        /// <returns>Returns a member OR throws exception if there is no assignee</returns>
        public IMember GetAssignee()
        {
            if (this.Assignee==null)
            {
                throw new ArgumentException("There is no assignee.");
            }
            return this.Assignee;
        }

        /// <summary>
        /// Changing the priority type of a story
        /// </summary>
        /// <param name="priority">The priority type we want the story to be changed to</param>
        /// <returns>Returns a string saying what the story priority type has been changed to or returns a message that it is already at the desired priority type</returns>
        public string ChangePriority(PriorityType priority)
        {
            if (this.Priority == priority)
            {
                throw new ArgumentException($"Priority already at '{priority}'.");
            }
            this.Priority = priority;
            return $"Story priority changed to '{priority}'.";
        }

        /// <summary>
        /// Changing the size type of a story
        /// </summary>
        /// <param name="size">The size type we want the story to be changed to</param>
        /// <returns>Returns a string saying what the story size type has been changed to or returns a message that it is already at the desired size type</returns>
        public string ChangeSize(SizeType size)
        {
            if (this.Size == size)
            {
                throw new ArgumentException($"Size already at '{size}'.");
            }
            this.Size = size;
            return $"Story size changed to '{size}'.";
        }

        /// <summary>
        /// Changing the status of a story
        /// </summary>
        /// <param name="status">The status we want the story to be changed to</param>
        /// <returns>Returns a string saying what the story status has been changed to or returns a message that it is already at the desired status</returns>
        public string ChangeStatus(StoryStatusType status)
        {
            if (this.StoryStatus == status)
            {
                throw new ArgumentException($"Status already at '{status}'.");
            }
            this.StoryStatus = status;
            return $"Story status changed to '{status}'.";
        }

        public override string ToString()
        {
            string assigneetext = this.Assignee == null ? "No assignee" : this.Assignee.Name;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Story ----");
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Priority: {this.priorityType}");
            sb.AppendLine($"Status: {this.storyStatus}");
            sb.AppendLine($"Size: {this.sizeType}");
            sb.AppendLine($"Assignee: {assigneetext}");

            return sb.ToString().Trim();
        }
    }
}
