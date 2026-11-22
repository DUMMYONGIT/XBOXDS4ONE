using System;
using CommunityToolkit.Mvvm.Input;

namespace XBOXDS4ONE.ViewModels
{
    /// <summary>One XBOXDS4ONE PC discovered on the LAN (issue #138), shown in the
    /// Remote Link page's list of nearby PCs. Clicking Pair starts the pairing, with no IP to type.</summary>
    public sealed class RemoteLinkNearbyPeer
    {
        public RemoteLinkNearbyPeer(string name, string hostPort, string fingerprintHex, bool isPaired, bool isConnected, Action<string> onPair)
        {
            Name = name;
            HostPort = hostPort;
            FingerprintHex = fingerprintHex;
            IsPaired = isPaired;
            IsConnected = isConnected;
            PairCommand = new RelayCommand(() => onPair?.Invoke(hostPort));
        }

        public string Name { get; }
        public string HostPort { get; }
        public string FingerprintHex { get; }
        public bool IsPaired { get; }
        public bool IsConnected { get; }

        /// <summary>Name with a state suffix.</summary>
        public string DisplayName =>
            IsConnected ? $"{Name} {XBOXDS4ONE.Resources.Strings.Strings.Instance.RemoteLink_PeerConnectedSuffix}"
            : IsPaired ? $"{Name} {XBOXDS4ONE.Resources.Strings.Strings.Instance.RemoteLink_PeerPairedSuffix}" : Name;

        /// <summary>Button text by state: Connected (disabled) / Connect (paired) / Pair (new).</summary>
        public string ButtonLabel =>
            IsConnected ? XBOXDS4ONE.Resources.Strings.Strings.Instance.RemoteLink_Connected
            : IsPaired ? XBOXDS4ONE.Resources.Strings.Strings.Instance.RemoteLink_Connect
            : XBOXDS4ONE.Resources.Strings.Strings.Instance.Dashboard_RemoteLinkPairButton;

        /// <summary>The action button is disabled while a live session already exists.</summary>
        public bool CanPair => !IsConnected;

        public RelayCommand PairCommand { get; }
    }
}
