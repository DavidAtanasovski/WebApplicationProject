using System;
using System.Collections.Generic;
using System.Text;
using WebProjectCore;
using WebProjectCore.PlayerSupport;

namespace WebProjectData
{
    public interface iPlayerSupport
    {
        PlayerSupport Create(PlayerSupport playerSupport);

        int Commit();

        PlayerSupport GetPlayerSupportById(int supportId);

        IEnumerable<PlayerSupport> GetPlayerSupports(string name = null);
    }
}
