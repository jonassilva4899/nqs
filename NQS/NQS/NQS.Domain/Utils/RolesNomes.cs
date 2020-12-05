using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leega.Domain.Utils
{
    public static class RolesNomes
    {
        public const string GoobeeAdmin = "GoobeeAdmin";
        public const string OrganizationAdmin = "OrganizationAdmin";
        public const string AgileCoach = "AgileCoach";
        public const string TeamLeader = "TeamLeader";
        public const string TeamMember = "TeamMember";

        public const string Todos = GoobeeAdmin + "," + OrganizationAdmin + "," + AgileCoach + "," + TeamLeader + "," + TeamMember;
        public const string Admins = GoobeeAdmin + "," + OrganizationAdmin;
        public const string AgileCoach_TeamLeader = AgileCoach + "," + TeamLeader;
    }
}
