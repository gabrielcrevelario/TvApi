using System;
using System.Collections.Generic;
using System.Linq;
using TvApi.Domain.DTO;
using TvApi.Domain.Interfaces;
using TvApi.Models;

namespace TvApi.Applications
{
    public class AudienceTvChannelService : IAudienceTvChannelService
    {
        private IAudienceRepository AudienceRepository { get; }
        private ITvChannelRepository TvChannelRepository { get; }

        public AudienceTvChannelService(IAudienceRepository audienceRepository, ITvChannelRepository tvChannelRepository)
        {
            AudienceRepository = audienceRepository;
            TvChannelRepository = tvChannelRepository;
        }

        public void CreateAudience(long tvId, Audience audience)
        {
            TvChannel tvChannel = GetTvChannelById(tvId);

            if (tvChannel == null)
            {
                throw new Exception("This ID already not exists in the database.");
            }
            if (tvChannel.Audiences != null)
            {
                tvChannel.Audiences.ForEach(element =>
                {
                    if (element.DateAndTimeAudience == audience.DateAndTimeAudience)
                    {
                        throw new Exception("audience data cannot be the same ");
                    }
                });
            }
            audience.TvChannelId = tvId;
            AudienceRepository.Create(audience);

        }
        public void CreateTvChannel(TvChannel tvChannel)
        {
            TvChannel tvFound = GetTvChannelByName(tvChannel.Name);
            try
            {
                if (tvFound == null)
                {
                    TvChannelRepository.Create(tvChannel);
                }
                else
                {
                    throw new Exception("This name already exists in the database.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<AudienceTvChannelDTO> ListAudiencesTvChannelWithAvarageHour(string desiredDate)
        {
            List<AudienceTvChannelDTO> listDTO = new List<AudienceTvChannelDTO>();
            TvChannelRepository.List().ForEach(x =>
            {
                if (x.Audiences.Count > 0)
                {
                    listDTO.Add(new AudienceTvChannelDTO()
                    {
                        NameChannel = x.Name,
                        AudiencePoints = x.Audiences.Where(a => a.DateAndTimeAudience.Hour == DateTime.Parse(desiredDate).Hour).Select(p => p.AudiencePoints).ToList().Sum(),
                        DateAndTimeAudience = DateTime.Parse(desiredDate),
                        AudienceAverage = x.Audiences.Where(a => a.DateAndTimeAudience == DateTime.Parse(desiredDate)).Select(p => p.AudiencePoints).ToList().Average()

                    });
                }
                else
                {
                    listDTO.Add(new AudienceTvChannelDTO()
                    {
                        NameChannel = x.Name,
                        AudiencePoints = 0,
                        DateAndTimeAudience = DateTime.Parse(desiredDate),
                        AudienceAverage = 0

                    });

                }
            });
            return listDTO;
        }
        public TvChannel GetTvChannelByName(string name)
        {
            return TvChannelRepository.GetByName(name);
        }
        private double CalculateSumPoints(List<double> points)
        {
            double result = 0;
            if (points.Count > 0)
            {
                points.ForEach(p =>
                {
                    result = +p;
                });
            }
            return result;
        }
        public TvChannel GetTvChannelById(long tvId)
        {
            var tvWithAudience = TvChannelRepository.GetByIdWithAudience(tvId);
            if (tvWithAudience != null)
            {
                return tvWithAudience;
            }
            return TvChannelRepository.GetById(tvId);
        }
        public Audience GetAudienceById(long tvId)
        {
            return AudienceRepository.GetById(tvId);
        }
        public void RemoveAudience(long audienceId)
        {
            Audience audience = GetAudienceById(audienceId);
            if (audience != null)
            {
                AudienceRepository.Delete(audienceId);
            }
            else
            {
                throw new Exception("This ID already not exists in the database.");
            }
        }
        public void RemoveTvChannel(long tvId)
        {
            TvChannel tvChannel = GetTvChannelById(tvId);
            List<Audience> audiences = AudienceRepository.List().Where(x => x.TvChannelId == tvId).ToList();
            if (audiences.Count() > 0)
            {
                AudienceRepository.DeleteTree(audiences);
                TvChannelRepository.Delete(tvId);
            }

        }
        public void UpdateAudience(long audienceId, Audience audience)
        {
            Audience audienceOld = GetAudienceById(audienceId);
            if (audienceOld != null)
            {
                audience.Id = audienceId;
                AudienceRepository.Update(audience);
            }
            else
            {
                throw new Exception("This ID already not exists in the database.");
            }
        }
        public void UpdateTvChannel(long tvId, TvChannel tvChannel)
        {
            TvChannel tvChannelOld = GetTvChannelById(tvId);
            if (tvChannelOld != null)
            {
                tvChannel.Id = tvId;
                TvChannelRepository.Update(tvChannel);
            }
            else
            {
                throw new Exception("This ID already not exists in the database.");
            }


        }
        public List<Audience> ListAudience()
        {
            return AudienceRepository.List();
        }
        public List<TvChannel> ListTvChannel()
        {
            return TvChannelRepository.List();
        }
    }
}
