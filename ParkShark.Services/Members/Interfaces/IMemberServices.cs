using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Services.Members.Interfaces
{
    public interface IMemberServices
    {
        Member AddMemberToDBContext(Member member);
    }
}
