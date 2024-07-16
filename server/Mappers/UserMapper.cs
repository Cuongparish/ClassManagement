using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Dtos.User;
using server.Models;

namespace server.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                id = userModel.id,
                email = userModel.email,
                pw = userModel.pw,
                fullName = userModel.fullName,
                dob = userModel.dob,
                sex = userModel.sex,
                phone = userModel.phone
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User
            {
                email = userDto.email,
                pw = userDto.pw,
                fullName = userDto.fullName,
                dob = userDto.dob,
                sex = userDto.sex,
                phone = userDto.phone
            };
        }
    }
}