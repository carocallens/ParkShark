﻿using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Services.Members.Interfaces
{
    public interface IMemberServices
    {
        List<Member> GetAllMembers();
        Member GetMember(Guid memberID);
        Member CreateNewMember(DummyMemberObject member);
        City ZIPExistsInDB(int zip);
        bool AddPhonenumersAndLicensPlatesToMember(DummyMemberObject dummyMember, Member givenMember);
    }
}
