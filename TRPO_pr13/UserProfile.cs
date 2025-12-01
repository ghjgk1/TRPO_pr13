using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO_pr13
{
    public class UserProfile : ObservableObject
    {
        int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value); 
        }

        string? _avatarUrl;
        public string? AvatarUrl
        {
            get => _avatarUrl;
            set => SetProperty(ref _avatarUrl, value);
        }

        string? _phone;
        public string? Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }


        DateTime? _birthday;
        public DateTime? Birthday
        {
            get => _birthday;
            set => SetProperty(ref _birthday, value);
        }

        string? _bio;
        public string? Bio
        {
            get => _bio;
            set => SetProperty(ref _bio, value);
        }

        int _userId;
        public int UserId
        { 
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        User _user;
        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }
    }
}
