using System;
using System.Collections.Generic;
using DevIct.PublicMeetings.Back.Data.Models;
using Google.Cloud.Firestore;

namespace DevIct.PublicMeetings.Back.Data.Firestore.Models
{
    [FirestoreData]
    internal class DbUser : User
    {
        public DbUser(
            Guid id,
            string firstName,
            string lastName,
            string username,
            UserRole role,
            string? email,
            List<Guid>? organizations = null,
            List<Guid>? meetings = null)
            : base(
                id,
                firstName,
                lastName,
                username,
                role,
                email)
        {
            Organizations = organizations ?? new List<Guid>();
            Meetings = meetings ?? new List<Guid>();
        }

        public DbUser(User user)
            : this(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Username,
                user.Role,
                user.Email)
        {
        }

        [FirestoreProperty]
        public override string FirstName { get; set; }

        [FirestoreProperty]
        public override string LastName { get; set; }

        [FirestoreProperty]
        public override string Username { get; set; }

        [FirestoreProperty]
        public override UserRole Role { get; set; }

        [FirestoreProperty]
        public override string? Email { get; set; }

        [FirestoreProperty]
        public List<Guid> Organizations { get; set; }

        [FirestoreProperty]
        public List<Guid> Meetings { get; set; }

        public static bool TryBuild(DocumentSnapshot snapshot, out DbUser user)
        {
            bool result = snapshot.TryGetValue(nameof(Id), out Guid id);
            result &= snapshot.TryGetValue(nameof(FirstName), out string firstName);
            result &= snapshot.TryGetValue(nameof(LastName), out string lastName);
            result &= snapshot.TryGetValue(nameof(Username), out string username);
            result &= snapshot.TryGetValue(nameof(Role), out UserRole role);
            result &= snapshot.TryGetValue(nameof(Email), out string? email);
            result &= snapshot.TryGetValue(nameof(Organizations), out List<Guid> organizations);
            result &= snapshot.TryGetValue(nameof(Meetings), out List<Guid> meetings);
            user = new DbUser(id, firstName, lastName, username, role, email, organizations, meetings);
            return result;
        }
    }
}
