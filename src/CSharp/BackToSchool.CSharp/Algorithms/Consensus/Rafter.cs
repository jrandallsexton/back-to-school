using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Algorithms.Consensus
{
    /// <summary>
    /// Personal implementation of the Raft algorithm for consensus-based operations
    /// </summary>
    public class Rafter
    {
        // Credit:  https://www.youtube.com/watch?v=IujMVjKvWP4
        // leader -> follower(s)
        // leader sends heartbeats to all followers
        // if heartbeat not received, follower can become a candidate node
        // with this, a new "term" must be created
        // timeout detection in followers must introduce jitter to prevent them all from assuming they are the next candidate
        // first detector, by default, becomes the candidate for the next term
        // all candidates must expose the log length
        // the longest log is the "true" candidate

        // now, how is the log synced:
        // each entry has: index & term

        // keep in-mind: appended vs committed

        // scenario: leader and 3 followers. one follower dies:
        // follower then comes back online ...
        // leader ALWAYS sends the PREVIOUS index & term ids
        // follower determines it does not exist, sends error to the leader
        // leader decrements the index, and sends again
        // up-to-date followers ignore; lagging follower says "nope. don't have that index either"
        // process continues until lagging follower is caught up

    }
}
