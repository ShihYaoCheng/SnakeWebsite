﻿namespace SnakeAsianLeague.Data.Entity.BlockChain
{
    public class BlockChainInfoDTO
    {
        // 區塊鏈資訊
        public string? blockChain { get; set; }
        public int chainId { get; set; }             // chainId
        public string? chainRPCUrl { get; set; }     // RPCUrl
        public string? socketServerUri { get; set; } // 接收Event回傳的Socket伺服器位置

        // 公用參數
        public string? nativeCurrencyName { get; set; }
        public int nativeCurrencyDecimals { get; set; }
        public int gasfeelimit { get; set; }
        public string? usdtAddress { get; set; }
        public int usdtDecimals { get; set; }
        public int srcDecimals { get; set; }

        /// <summary>
        /// google雲端照片儲存url
        /// </summary>
        public string googleapis { get; set; }

        public int tsrcDecimals { get; set; }
        public bool eventWarmUpStatus20221108 { get; set; }

        // Opensea
        public string openSeaURL_PPSR { get; set; }
        public string openSeaURL_PPSBP { get; set; }
        public string openSeaLink { get; set; }
        public string openSeaURL_PPSL { get; set; }

        // PPSR合約
        public string? adminWalletAddress_PPSR { get; set; }
        public string? contractAddress_PPSR { get; set; }
        public decimal balanceOf_PPSR { get; set; } // 剩餘瓦斯費

        // SRCExchange合約
        public string? adminWalletAddress_SRCExchange { get; set; }
        public string? contractAddress_SRCExchange { get; set; }
        public decimal balanceOf_SRCExchange { get; set; }  // 剩餘瓦斯費

        // SRCSwap合約
        public string? adminWalletAddress_SRCSwap { get; set; }
        public string? contractAddress_SRCSwap { get; set; }
        public decimal balanceOf_SRCSwap { get; set; } // 剩餘瓦斯費

        // SRC ERC20合約
        public string? adminWalletAddress_SRC { get; set; }
        public string? contractAddress_SRC { get; set; }
        public decimal balanceOf_SRC { get; set; } // 剩餘瓦斯費

        // CQIPurchase合約
        public string? adminWalletAddress_CQIPurchase { get; set; }
        public string? contractAddress_CQIPurchase { get; set; }
        public decimal balanceOf_CQIPurchase { get; set; } // 剩餘瓦斯費    

        // PPSI合約
        public string? adminWalletAddress_PPSI { get; set; }
        public string? contractAddress_PPSI { get; set; }
        public decimal balanceOf_PPSI { get; set; } // 剩餘瓦斯費

        // PPSL合約
        public string? adminWalletAddress_PPSL { get; set; }
        public string? contractAddress_PPSL { get; set; }
        public decimal balanceOf_PPSL { get; set; } // 剩餘瓦斯費

        // 暫時性合約
        // tSRC ERC20合約 (2022-12 預熱活動專用)
        public string? adminWalletAddress_tSRC { get; set; }
        public string? contractAddress_tSRC { get; set; }
        public decimal balanceOf_tSRC { get; set; } // 剩餘瓦斯費
                                                    // tSRCExchange合約 (2022-12 預熱活動專用)
        public string? adminWalletAddress_tSRCExchange { get; set; }
        public string? contractAddress_tSRCExchange { get; set; }
        public decimal balanceOf_tSRCExchange { get; set; } // 剩餘瓦斯費

        // UserServer 呼叫贈送tSRC 專用錢包
        public string? eventWalletWallet_tSRC { get; set; }


        /// 功能開放狀態
        public bool swapStatus { get; set; }
    }



}
